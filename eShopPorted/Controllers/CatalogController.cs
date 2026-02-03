using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using eShopPorted.Models;
using eShopPorted.Services;
using log4net;
using Microsoft.Extensions.Logging;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Application.Catalog.Queries;
using System.Threading.Tasks;
using eShopPorted.Application.Catalog.Commands;

namespace eShopPorted.Controllers
{
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CatalogController> _logger;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ICatalogService service;
        public CatalogController(ICatalogService service, ILogger<CatalogController> logger, IMediator mediator)
        {
            this.service = service;
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        // GET /[?pageSize=3&pageIndex=10]
        public async Task<IActionResult> Index(int pageSize, int pageIndex)
        {
            var result = await _mediator.Send(new CatalogGetListQuery { PageSize = pageSize, PageIndex = pageIndex });
            return result.IsSuccess ? View(result.Value) : NotFound();
        }
        [HttpGet("{id}")]
        // GET: Catalog/Details/5
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var result = await _mediator.Send(new CatalogGetByIdQuery { Id = id });
            return result.IsSuccess ? View(result.Value) : NotFound();
        }
        [HttpPost]
        // GET: Catalog/Create
        public async Task<IActionResult> Create()
        {
            var result = await _mediator.Send(new CatalogCreateCommand());
            return result.IsSuccess ? View(result.Value) : NotFound();
        }// POST: Catalog/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] CatalogItem catalogItem)
        {
            var result = await _mediator.Send(new CatalogCreateCommand { CatalogItem = catalogItem });
            return result.IsSuccess ? View(result.Value) : NotFound();
        }
        [HttpPut("{id}")]
        // GET: Catalog/Edit/5
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var result = await _mediator.Send(new CatalogEditCommand { Id = id });
            return result.IsSuccess ? View(result.Value) : NotFound();
        }// POST: Catalog/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind] CatalogItem catalogItem)
        {
            var result = await _mediator.Send(new CatalogEditCommand { CatalogItem = catalogItem });
            return result.IsSuccess ? View(result.Value) : NotFound();
        }
        [HttpDelete("{id}")]
        // GET: Catalog/Delete/5
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new CatalogDeleteCommand { Id = id });
            return result.IsSuccess ? View(result.Value) : NotFound();
        }// POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {
            var result = await _mediator.Send(new CatalogDeleteConfirmedCommand { Id = id });
            return result.IsSuccess ? RedirectToAction("Index") : BadRequest();
        }
        protected override void Dispose(bool disposing)
        {
            _log.Debug($"Now disposing");
            if (disposing)
            {
                service.Dispose();
            }

            base.Dispose(disposing);
        }

        private void ChangeUriPlaceholder(IEnumerable<CatalogItem> items)
        {
            foreach (var catalogItem in items)
            {
                AddUriPlaceHolder(catalogItem);
            }
        }

        private void AddUriPlaceHolder(CatalogItem item)
        {
            item.PictureUri = $"/Pics/{item.Id}.png";
        }
    }
}