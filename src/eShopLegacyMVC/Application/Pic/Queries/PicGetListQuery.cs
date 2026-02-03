namespace eShopLegacyMVC.Application.Pic.Queries;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Application.Common.Extensions;
using eShopLegacyMVC.Models;
using Microsoft.Extensions.Logging;

/// <summary>
/// Query for Index operation.
/// Generated with 80% confidence from PicController.Index.
/// </summary>
public record PicGetListQuery(int CatalogItemId) : IRequest<Result>;

/// <summary>
/// Handles the PicGetListQuery query.
/// </summary>
public sealed class PicGetListHandler : IRequestHandler<PicGetListQuery, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<PicGetListHandler> _logger;

    public PicGetListHandler(IApplicationDbContext context, ILogger<PicGetListHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result> Handle(PicGetListQuery request, CancellationToken cancellationToken)
    {
        // Business logic from PicController.Index
        if (request.CatalogItemId <= 0)
        {
            return Result.Success(StatusCode(HttpStatusCode.BadRequest));
        }
        var item = await _context.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType).FirstOrDefaultAsync(ci => ci.Id == id);
        if (item != null)
        {
            var webRoot = Server.MapPath("~/Pics");
            var path = Path.Combine(webRoot, item.PictureFileName);
            string imageFileExtension = Path.GetExtension(item.PictureFileName);
            string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);
            var buffer = System.IO.File.ReadAllBytes(path);
            return Result.Success(File(buffer, mimetype));
        }
        return Result.Failure("Not found");
    }

    /// <summary>
    /// Private helper method migrated from controller.
    /// TODO: Review and adapt as needed for handler context.
    /// </summary>
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
