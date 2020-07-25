using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DataProcessor.Readers
{
    public class DirrectoryModelReader : IModelReader
    {
        private static DirrectoryModelReader _dirrectoryModelReader;

        public async Task<JObject> ReadAsync()
        {
            return null;
        }

        public static DirrectoryModelReader Get() =>
            _dirrectoryModelReader ??= new DirrectoryModelReader();
    }
}