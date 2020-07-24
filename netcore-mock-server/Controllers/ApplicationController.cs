using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using netcore_mock_server.Configuration;

namespace netcore_mock_server.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private IApplicationConfig _config;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationConfig config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return null;
        }
    }
}
