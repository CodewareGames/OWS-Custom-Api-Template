using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;
using OWSShared.Interfaces;
using Serilog;
using OWSCustomApi.Requests.Hello;


namespace OWSCustomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : Controller
    {
        private readonly ILogger _logger;
        private readonly Container _container;
        private readonly IHeaderCustomerGUID _customerGuid;

        public HelloController(ILogger logger, Container container, IHeaderCustomerGUID customerGuid)
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
            _logger.Information("Hello Controller Invoked");

            WorldRequest request = new WorldRequest();
            request.SetData(_logger, _customerGuid);

            return await request.Handle();
        }
    }
}