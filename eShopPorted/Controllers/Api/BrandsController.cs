using System.Linq;
using Microsoft.AspNetCore.Mvc;
using eShopPorted.Services;
using Microsoft.Extensions.Logging;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Application.Brands.Queries;
using System.Threading.Tasks;
using eShopPorted.Application.Brands.Commands;

namespace eShopPorted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BrandsController> _logger;
        private readonly ICatalogService _service;

        public BrandsController(ICatalogService service, ILogger<BrandsController> logger, IMediator mediator)
        {
            _service = service;
            _logger = logger; _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new BrandsGetListQuery());
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new BrandsDeleteCommand { Id = id });
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
    }
}
