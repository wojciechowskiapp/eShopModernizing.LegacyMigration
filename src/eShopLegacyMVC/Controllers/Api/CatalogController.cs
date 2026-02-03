using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Application.Catalog2.Queries;
using System.Threading.Tasks;

namespace eShopLegacyMVC.Controllers.Api
{
    [Route("api")]
    public class CatalogController2 : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CatalogController2> _logger;
        public CatalogController2(ILogger<CatalogController2> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new Catalog2GetListQuery());
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
    }
}