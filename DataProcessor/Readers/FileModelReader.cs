using DataProcessor.Configuration;
using MoveRouting.Models;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DataProcessor.Readers
{
    public class FileModelReader : IModelReader
    {
        private static IApplicationConfig _config;
        private static FileModelReader _fileModelReader;

        // ReSharper disable once InconsistentNaming
        private const string ROUTE_FILE_NAME = "routes.json";
        public FileModelReader(IApplicationConfig config)
        {
            _config = config;
        }

        public async Task<JObject> ReadAsync(RouteModel routeModel)
        {
            var entireModel = await GEtEntireModel();
            return string.IsNullOrEmpty(routeModel.Key)
                ? await GetModelCollectionAsync(entireModel, routeModel)
                : await GetModelAsync(entireModel, routeModel);
        }

        #region private

        private static string GetPath() =>
            Path.Combine(_config.PathToRootFolder, ROUTE_FILE_NAME);

        private static async Task<JObject> GetModelCollectionAsync(JObject entireModel, RouteModel routeModel)
            => await Task.Run(() => GetRootModel(entireModel, routeModel.RootRoute)?
                .Value<JObject>());

        private static async Task<JObject> GetModelAsync(JObject entireModel, RouteModel routeModel)
        {
            var collectionModel = await GetModelCollectionAsync(entireModel, routeModel);
            return collectionModel.SelectToken(routeModel.Key)?.Value<JObject>();
        }

        private static JToken GetRootModel(JObject entireModel, string rootRoute)
        {
            entireModel.TryGetValue(rootRoute, StringComparison.OrdinalIgnoreCase, out var rootModel);
            return rootModel;
        }

        private static async Task<JObject> GEtEntireModel()
        {
            string jsonString;

            using (var streamReader = new StreamReader(GetPath()))
            {
                jsonString = await streamReader.ReadToEndAsync();
            }

            return JObject.Parse(jsonString);
        }

        #endregion
    }
}