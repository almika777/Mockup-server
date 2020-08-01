using System.Threading.Tasks;
using MoveRouting.Models;
using Newtonsoft.Json.Linq;

namespace DataProcessor.Readers
{
    public interface IModelReader
    {
        Task<JObject> ReadAsync(RouteModel routeModel);
    }
}
