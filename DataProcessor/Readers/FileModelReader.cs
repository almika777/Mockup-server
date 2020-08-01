using DataProcessor.Configuration;
using MoveRouting.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessor.Readers
{
    public class FileModelReader : IModelReader
    {
        private static IApplicationConfig _config;
        private static FileModelReader _fileModelReader;
        public FileModelReader(IApplicationConfig config)
        {
            _config = config;
        }

        private FileModelReader() { }

        public async Task<JObject> ReadAsync(RouteModel routeModel)
        {
            var entireModel = await GEtEntireModel();
            return string.IsNullOrEmpty(routeModel.Key)
                ? await GetAll(entireModel, routeModel)
                : await GetByKey(entireModel, routeModel);
        }

        public static IModelReader Get(IApplicationConfig config) =>
            _fileModelReader ??= new FileModelReader(config);

        #region private

        private static string GetPath() =>
            Path.Combine(_config.PathToRootFolder, "routes.json");

        private static async Task<JObject> GetAll(JObject entireModel, RouteModel routeModel)
            => await Task.Run(() => GetRootModel(entireModel, routeModel.RootRoute)?
                .Value<JObject>());

        private static async Task<JObject> GetByKey(JObject entireModel, RouteModel routeModel)
            => await Task.Run(() => GetRootModel(entireModel, routeModel.RootRoute)
                    .SelectToken(routeModel.Key)?.Value<JObject>());

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