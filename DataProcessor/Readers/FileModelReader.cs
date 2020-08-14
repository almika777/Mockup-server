using DataProcessor.Configuration;
using MoveRouting.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;

namespace DataProcessor.Readers
{
    public class FileModelReader : IModelReader
    {
        private static IApplicationConfig _config;

        // ReSharper disable once InconsistentNaming
        private const string ROUTE_FILE_NAME = "routes.json";

        public FileModelReader(IApplicationConfig config)
        {
            _config = config;
        }

        public async Task<JObject> ReadAsync(RouteModel routeModel)
            => GetModel(await GEtEntireModel(), routeModel);

        #region private

        private string GetPath() =>
            Path.Combine(_config.PathToRootFolder, ROUTE_FILE_NAME);

        private JObject GetModel(JToken entireModel, RouteModel routeModel)
            => entireModel.SelectToken(routeModel.Route)?.Value<JObject>();
        
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