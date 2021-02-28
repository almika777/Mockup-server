using Common.Enums;
using Common.Models;
using DataProcessor.Configuration;
using DataProcessor.JsonFilters;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;

namespace DataProcessor.Readers
{
    public class FileModelReader : IModelReader
    {
        private static IApplicationConfig _config;
        private readonly FilterFactory _filterFactory;

        public FileModelReader(IApplicationConfig config, FilterFactory filterFactory)
        {
            _config = config;
            _filterFactory = filterFactory;
        }

        public async Task<JToken> ReadAsync(RouteModel routeModel)
            => GetModel(await GetEntireModel(), routeModel);

        #region private

        private string GetPath() => Path.Combine(_config.PathToRootFolder, _config.FileName);

        private JToken GetModel(JToken entireModel, RouteModel routeModel)
        {
            var res = entireModel.SelectToken(routeModel.Route.ToLower());
            var filter = _filterFactory.GetFilter(GetFilterType(res));

            return !string.IsNullOrEmpty(routeModel.Query)
                ? filter.FilterToken(res, routeModel)
                : res;
        }

        private static FilterType GetFilterType(JToken res) => res?.Type == JTokenType.Array 
            ? FilterType.Array 
            : FilterType.Dictionary;
        
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