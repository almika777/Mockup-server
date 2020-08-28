using DataProcessor.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using DataProcessor.Models;

namespace DataProcessor.Readers
{
    public class DirrectoryModelReader : IModelReader
    {
        private static DirrectoryModelReader _dirrectoryModelReader;
        private IApplicationConfig _config;

        public DirrectoryModelReader(IApplicationConfig config)
        {
            _config = config;
        }

        public Task<JToken> ReadAsync(RouteModel routeModel)
        {
            return null;
        }
    }
}