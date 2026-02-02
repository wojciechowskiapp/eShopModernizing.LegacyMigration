using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
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
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BrandsController> _logger;
        private ICatalogService _service;
        public BrandsController(ICatalogService service, ILogger<BrandsController> logger, IMediator mediator)
        {
            _service = service;
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        // GET api/<controller>
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new BrandsGetFormQuery());
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
        [HttpGet("{id:int}")]
        // GET api/<controller>/5
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new BrandsGetFormQuery { Id = id });
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
        [HttpDelete]
        // DELETE api/<controller>/5
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new BrandsDeleteCommand { Id = id });
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
    }
}