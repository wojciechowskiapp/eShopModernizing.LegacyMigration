namespace eShopLegacyMVC.Application.Catalog.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;

/// <summary>
/// Command for Delete operation.
/// Generated with 80% confidence from CatalogController.Delete.
/// </summary>
public record CatalogDeleteCommand(int? Id) : IRequest<Result>;

/// <summary>
/// Handles the CatalogDeleteCommand command.
/// </summary>
public sealed class CatalogDeleteHandler : IRequestHandler<CatalogDeleteCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public CatalogDeleteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Result> Handle(CatalogDeleteCommand request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.Delete
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
        catalogItem.PictureUri = this.Url.RouteUrl(PicController.GetPicRouteName, new { catalogItemId = catalogItem.Id }, this.Request.Url.Scheme);;
        return Result.Success(catalogItem);
    }
}
