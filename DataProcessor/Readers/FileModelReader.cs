using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DataProcessor.Readers
{
    public class FileModelReader : IModelReader
    {
        private static FileModelReader _fileModelReader;

        public async Task<JObject> ReadAsync()
        {
            return null;
        }

        public static FileModelReader Get() =>
            _fileModelReader ??= new FileModelReader();
    }
}