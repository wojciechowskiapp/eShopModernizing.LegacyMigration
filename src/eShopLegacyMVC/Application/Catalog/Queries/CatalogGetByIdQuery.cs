namespace eShopLegacyMVC.Application.Catalog.Queries;

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
/// Query for Details operation.
/// Generated with 80% confidence from CatalogController.Details.
/// </summary>
public record CatalogGetByIdQuery(int? Id) : IRequest<Result>;

/// <summary>
/// Handles the CatalogGetByIdQuery query.
/// </summary>
public sealed class CatalogGetByIdHandler : IRequestHandler<CatalogGetByIdQuery, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CatalogGetByIdHandler> _logger;

    public CatalogGetByIdHandler(IApplicationDbContext context, ILogger<CatalogGetByIdHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<Result> Handle(CatalogGetByIdQuery request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.Details
        if (request.Id == null)
        {
            return Result.Success(StatusCode(HttpStatusCode.BadRequest));
        }
        CatalogItem catalogItem = _context. /* TODO: Verify this service call transformation */FindCatalogItem(request.Id.Value);
        if (catalogItem == null)
        {
            return Result.Failure("Not found");
        }
        AddUriPlaceHolder(catalogItem);
        return Result.Success(catalogItem);
    }

    /// <summary>
    /// Private helper method migrated from controller.
    /// TODO: Review and adapt as needed for handler context.
    /// </summary>
    private void AddUriPlaceHolder(CatalogItem item)
    {
        item.PictureUri = this.Url.RouteUrl(PicController.GetPicRouteName, new { catalogItemId = item.Id }, this.Request.Url.Scheme);
    }
}
