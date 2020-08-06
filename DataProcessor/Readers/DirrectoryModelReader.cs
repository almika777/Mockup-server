using DataProcessor.Configuration;
using MoveRouting.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

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

        public Task<JObject> ReadAsync(RouteModel routeModel)
        {
            return null;
        }
    }
}