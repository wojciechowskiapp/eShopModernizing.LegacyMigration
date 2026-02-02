namespace eShopLegacyMVC.Application.Catalog.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Command for Edit operation.
/// Generated with 75% confidence from CatalogController.Edit.
/// </summary>
public record CatalogEditCommand(CatalogItem CatalogItem) : IRequest<Result>;

/// <summary>
/// Response DTO for CatalogEditCommand containing ViewBag/ViewData properties.
/// </summary>
public record CatalogEditResponseDto
{
    /// <summary>
    /// Gets or initializes CatalogBrandId.
    /// </summary>
    public IEnumerable<SelectListItem> CatalogBrandId { get; init; }

    /// <summary>
    /// Gets or initializes CatalogTypeId.
    /// </summary>
    public IEnumerable<SelectListItem> CatalogTypeId { get; init; }

}

/// <summary>
/// Handles the CatalogEditCommand command.
/// TODO: Review implementation - generated with 75% confidence.
/// </summary>
public sealed class CatalogEditHandler : IRequestHandler<CatalogEditCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public CatalogEditHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Result> Handle(CatalogEditCommand request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.Edit
        var result = new CatalogEditResponseDto();

        if (id == null)
        {
        return Result.Success(StatusCode(HttpStatusCode.BadRequest));
        }
        CatalogItem catalogItem = _context. /* TODO: Verify this service call transformation */FindCatalogItem(id.Value);
        if (catalogItem == null)
        {
        return Result.Failure("Not found");
        }
        // TODO: Private method AddUriPlaceHolder() is also used by: Edit, Delete
        // Consider extracting to a shared helper class or domain service
        catalogItem.PictureUri = this.Url.RouteUrl(PicController.GetPicRouteName, new { catalogItemId = catalogItem.Id }, this.Request.Url.Scheme);;
        result.CatalogBrandId = new SelectList(_context.CatalogBrands, "Id", "Brand", catalogItem.CatalogBrandId);
        result.CatalogTypeId = new SelectList(_context.CatalogTypes, "Id", "Type", catalogItem.CatalogTypeId);
        return Result.Success(catalogItem);
    }
}
