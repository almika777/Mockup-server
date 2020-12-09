using Common.Models;
using DataProcessor.Configuration;
using DataProcessor.JsonFilters;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using Common.Enums;

namespace DataProcessor.Readers
{
    public class FileModelReader : IModelReader
    {
        private static IApplicationConfig _config;
        private readonly FilterFactory _factory;

        public FileModelReader(IApplicationConfig config, FilterFactory factory)
        {
            _config = config;
            _factory = factory;
        }

        public async Task<JToken> ReadAsync(RouteModel routeModel)
            => GetModel(await GetEntireModel(), routeModel);

        #region private

        private string GetPath() => Path.Combine(_config.PathToRootFolder, _config.FileName);

        private JToken GetModel(JToken entireModel, RouteModel routeModel)
        {
            var filter = _factory.GetFilter(FilterType.Array);
            var res = entireModel.SelectToken(routeModel.Route.ToLower());
            return !string.IsNullOrEmpty(routeModel.Query)
                ? filter.FilterToken(res, routeModel)
                : res;
        }

        private async Task<JObject> GetEntireModel()
        {
            string jsonString;

            using (var streamReader = new StreamReader(GetPath()))
            {
                jsonString = await streamReader.ReadToEndAsync();
            }

            return JObject.Parse(jsonString.ToLower());
        }
        #endregion private
    }
}