using DataProcessor;
using DataProcessor.Configuration;
using DataProcessor.Readers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using MoveRouting;
using MoveRouting.Models;

namespace netcore_mock_server.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private IApplicationConfig _config;
        private readonly IModelReader _modelReader;
        public ApplicationController(ILogger<ApplicationController> logger, IApplicationConfig config,
            ModelReaderFactory modelReaderFactory)
        {
            _logger = logger;
            _config = config;
            _modelReader = modelReaderFactory.GetModelReader(config);
        }

        [HttpGet("{rootRoute}/{key?}")]
        public async Task<JObject> Get([FromRoute] RouteModel routeModel) 
            => await _modelReader.ReadAsync(routeModel);
    }
}
