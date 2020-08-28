using DataProcessor;
using DataProcessor.Readers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using DataProcessor.Models;

namespace Web.Controllers
{
    [ApiController, Route("/api")]
    public class ApplicationController : ControllerBase
    {
        private readonly IModelReader _modelReader;
        public ApplicationController(ModelReaderFactory modelReaderFactory)
        {
            _modelReader = modelReaderFactory.GetModelReader();
        }

        [HttpGet]
        public async Task<JToken> Get([FromQuery] RouteModel model)
        {
            var a = await _modelReader.ReadAsync(model);
            return a;
        }
            
    }
}
