using System.Threading.Tasks;
using Common.Models;
using Newtonsoft.Json.Linq;

namespace DataProcessor.Readers
{
    public interface IModelReader
    {
        Task<JToken> ReadAsync(RouteModel routeModel);
    }
}
