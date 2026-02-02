using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eShopLegacy.Utilities;
using eShopLegacyMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eShopLegacyMVC.Application.Common.Interfaces;

namespace eShopLegacyMVC.Controllers.WebApi
{
[ApiController]
[Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
    private readonly IMediator _mediator;
    private readonly ILogger<FilesController> _logger;
        private ICatalogService _service;

        public FilesController(ICatalogService service, ILogger<FilesController> logger, IMediator mediator) {
            _service = service;
_logger = logger;         _mediator = mediator; }
[HttpGet]
// GET api/<controller>
public async Task<IActionResult> Get()
{
    var result = await _mediator.Send(new FilesGetQuery());
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