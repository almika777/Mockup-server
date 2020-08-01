using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using MoveRouting.Models;

namespace DataProcessor.Readers
{
    public class DirrectoryModelReader : IModelReader
    {
        private static DirrectoryModelReader _dirrectoryModelReader;

        public Task<JObject> ReadAsync(RouteModel routeModel)
        {
            return null;
        }

        public static IModelReader Get() =>
             _dirrectoryModelReader ??= new DirrectoryModelReader();

    }
}