using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using eShopLegacyMVC.Services;
using log4net;
using Microsoft.Extensions.Logging;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Application.Pic.Queries;
using System.Threading.Tasks;

namespace eShopLegacyMVC.Controllers
{
    [Route("[controller]")]
    public class PicController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PicController> _logger;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public const string GetPicRouteName = "GetPicRouteTemplate";
        private ICatalogService service;
        public PicController(ICatalogService service, ILogger<PicController> logger, IMediator mediator)
        {
            this.service = service;
            _logger = logger;
            _mediator = mediator;
        }
        // GET: Pic/5.png
        [HttpGet]
        [Route("items/{catalogItemId:int}/pic", Name = GetPicRouteName)]
        public async Task<IActionResult> Index(int catalogItemId)
        {
            var result = await _mediator.Send(new PicGetListQuery { CatalogItemId = catalogItemId });
            return result.IsSuccess ? Ok() : BadRequest();
        }
        private string GetImageMimeTypeFromImageFileExtension(string extension)
        {
            string mimetype;
            switch (extension)
            {
                case ".png":
                    mimetype = "image/png";
                    break;
                case ".gif":
                    mimetype = "image/gif";
                    break;
                case ".jpg":
                case ".jpeg":
                    mimetype = "image/jpeg";
                    break;
                case ".bmp":
                    mimetype = "image/bmp";
                    break;
                case ".tiff":
                    mimetype = "image/tiff";
                    break;
                case ".wmf":
                    mimetype = "image/wmf";
                    break;
                case ".jp2":
                    mimetype = "image/jp2";
                    break;
                case ".svg":
                    mimetype = "image/svg+xml";
                    break;
                default:
                    mimetype = "application/octet-stream";
                    break;
            }

            return mimetype;
        }
    }
}