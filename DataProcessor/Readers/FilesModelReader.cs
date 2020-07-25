using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DataProcessor.Readers
{
    public class FilesModelReader : IModelReader
    {
        private static FilesModelReader _filesModelReader;

        public async Task<JObject> ReadAsync()
        {
            return null;
        }

        public static FilesModelReader Get() =>
            _filesModelReader ??= new FilesModelReader();
    }
}