using Microsoft.AspNetCore.Mvc;
using OWSShared.Interfaces;

namespace OWSCustomApi.Requests.Test
{
    public class WorldRequest : IRequestHandler<WorldRequest, IActionResult>, IRequest
    {
        private ILogger logger;

        private Guid customerGUID;

        public void SetData(ILogger logger, IHeaderCustomerGUID customerGuid)
        {
            this.logger = logger;
            this.customerGUID = customerGuid.CustomerGUID;
        }

        public async Task<IActionResult> Handle()
        {
            logger.LogInformation("Hello World Request Handled");
            return new OkObjectResult("Hello World!");
        }
    }
}
