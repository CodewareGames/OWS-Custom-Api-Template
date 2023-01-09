using Microsoft.AspNetCore.Mvc;
using OWSCustomApi.Requests.Test;
using OWSShared.Interfaces;
using SimpleInjector;

namespace OWSCustomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : Controller
    {
        private readonly ILogger _logger;
        private readonly Container _container;
        private readonly IHeaderCustomerGUID _customerGuid;

        public HelloController(ILogger<HelloController> logger, Container container, IHeaderCustomerGUID customerGuid)
        {
            _logger = logger;
            _container = container;
            _customerGuid = customerGuid;
        }

        [HttpGet]
        [Produces(typeof(WorldRequest))]
        [Route("World")]
        public async Task<IActionResult> World()
        {
            _logger.LogInformation("Hello Controller Invoked");

            WorldRequest request = new WorldRequest();
            request.SetData(_logger, _customerGuid);

            return await request.Handle();
        }
    }
}