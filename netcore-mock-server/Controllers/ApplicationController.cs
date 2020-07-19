using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace netcore_mock_server.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return null;
        }
    }
}
