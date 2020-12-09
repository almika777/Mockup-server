using DataProcessor;
using DataProcessor.Readers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Common.Models;

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
            => await _modelReader.ReadAsync(model);
    }
}
