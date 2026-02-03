using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using eShopLegacy.Utilities;
using eShopPorted.Services;
using Microsoft.Extensions.Logging;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Application.Files.Queries;
using System.Threading.Tasks;

namespace eShopPorted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FilesController> _logger;
        private readonly ICatalogService _service;

        public FilesController(ICatalogService service, ILogger<FilesController> logger, IMediator mediator)
        {
            _service = service;
            _logger = logger; _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new FilesGetListQuery());
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
        [Serializable]
        public class BrandDTO
        {
            public int Id { get; set; }
            public string Brand { get; set; }
        }
    }
}
