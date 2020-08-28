using DataProcessor.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataProcessor.Models;

namespace DataProcessor.Readers
{
    public class FileModelReader : IModelReader
    {
        private static IApplicationConfig _config;
        private readonly JsonFilter _jsonFilter;

        // ReSharper disable once InconsistentNaming
        private const string ROUTE_FILE_NAME = "routes.json";

        public FileModelReader(IApplicationConfig config, JsonFilter jsonFilter = null)
        {
            _config = config;
            _jsonFilter = jsonFilter;
        }

        public async Task<JToken> ReadAsync(RouteModel routeModel)
            => GetModel(await GEtEntireModel(), routeModel);

        #region private

        private string GetPath() =>
            Path.Combine(_config.PathToRootFolder, ROUTE_FILE_NAME);

        private JToken GetModel(JToken entireModel, RouteModel routeModel)
        {
            var res = entireModel.SelectToken(routeModel.Route);
            var filter = _jsonFilter.FilterToken(res,routeModel);

            return JToken.FromObject(res);
        } 
        
        private async Task<JObject> GEtEntireModel()
        {
            string jsonString;

            using (var streamReader = new StreamReader(GetPath()))
            {
                jsonString = await streamReader.ReadToEndAsync();
            }

            return JObject.Parse(jsonString);
        }

        #endregion private
    }
}