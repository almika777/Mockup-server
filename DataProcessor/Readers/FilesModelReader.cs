using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Common.Models;
using DataProcessor.Configuration;

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

        public Task<JToken> ReadAsync(RouteModel routeModel)
        {
            return null;
        }
    }
}