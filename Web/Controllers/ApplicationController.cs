using System.Threading.Tasks;
using DataProcessor;
using DataProcessor.Configuration;
using DataProcessor.Readers;
using Microsoft.AspNetCore.Mvc;
using MoveRouting.Models;
using Newtonsoft.Json.Linq;

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

        [HttpGet("{route}")]
        public async Task<JObject> Get(string route)
            => await _modelReader.ReadAsync(new RouteModel(route));
    }
}
