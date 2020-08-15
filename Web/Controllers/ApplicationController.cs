using DataProcessor;
using DataProcessor.Configuration;
using DataProcessor.Readers;
using Microsoft.AspNetCore.Mvc;
using MoveRouting.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController, Route("/api")]
    public class ApplicationController : ControllerBase
    {
        private readonly IModelReader _modelReader;
        public ApplicationController(IApplicationConfig config, ModelReaderFactory modelReaderFactory)
        {
            _modelReader = modelReaderFactory.GetModelReader(config);
        }

        [HttpGet]
        public async Task<JObject> Get([FromQuery] RouteModel model)
            => await _modelReader.ReadAsync(model);
    }
}
