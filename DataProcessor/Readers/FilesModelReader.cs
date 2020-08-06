using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using DataProcessor.Configuration;
using MoveRouting.Models;

namespace DataProcessor.Readers
{
    public class FilesModelReader : IModelReader
    {
        private static FilesModelReader _filesModelReader;
        private IApplicationConfig _config;

        public FilesModelReader(IApplicationConfig config)
        {
            _config = config;
        }

        public Task<JObject> ReadAsync(RouteModel routeModel)
        {
            return null;
        }
    }
}