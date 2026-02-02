namespace eShopLegacyMVC.Application.Catalog.Queries;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;

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

    public CatalogGetByIdHandler(IApplicationDbContext context)
    {
        _context = context;
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
        // TODO: Private method AddUriPlaceHolder() is also used by: Edit, Delete
        // Consider extracting to a shared helper class or domain service
        catalogItem.PictureUri = this.Url.RouteUrl(PicController.GetPicRouteName, new { catalogItemId = catalogItem.Id }, this.Request.Url.Scheme); ;
        return Result.Success(catalogItem);
    }
}
