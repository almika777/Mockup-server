using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using MoveRouting.Models;

namespace DataProcessor.Readers
{
    public class FilesModelReader : IModelReader
    {
        private static FilesModelReader _filesModelReader;

        public static IModelReader Get() =>
            _filesModelReader ??= new FilesModelReader();

        public Task<JObject> ReadAsync(RouteModel routeModel)
        {
            return null;
        }
    }
}