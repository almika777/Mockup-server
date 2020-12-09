using Common.Models;
using DataProcessor.Readers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController, Route("/api")]
    public class ApplicationController : ControllerBase
    {
        private readonly IModelReader _modelReader;
        public ApplicationController(IModelReader modelReader)
        {
            _modelReader = modelReader;
        }

        [HttpGet]
        public async Task<JToken> Get([FromQuery] RouteModel model)
            => await _modelReader.ReadAsync(model);
    }
}
