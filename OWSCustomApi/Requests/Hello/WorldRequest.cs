using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OWSShared.Interfaces;
using Serilog;

namespace OWSCustomApi.Requests.Hello
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
            logger.Information("Hello World Request Handled");
            return new OkObjectResult("Hello World!");
        }
    }
}
