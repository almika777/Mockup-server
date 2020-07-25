using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataProcessor.Readers
{
    public interface IModelReader
    {
        Task<JObject> ReadAsync();
    }
}
