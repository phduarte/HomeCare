using Microsoft.AspNetCore.Mvc;

namespace HomeCare.WebApi.Controllers
{
    [ApiController]
    [Route("v1/public/test")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index([FromBody]object id)
        {
            _logger.LogInformation($"message received: {id}");
            return Ok(id);
        }
    }
}
