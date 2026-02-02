namespace eShopPorted.Application.Catalog.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopPorted.Application.Common;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// Command for Edit operation.
/// Generated with 75% confidence from CatalogController.Edit.
/// </summary>
public record CatalogEditPutCommand(int? Id) : IRequest<Result>;

/// <summary>
/// Response DTO for CatalogEditPutCommand containing ViewBag/ViewData properties.
/// </summary>
public record CatalogEditPutResponseDto
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
/// Handles the CatalogEditPutCommand command.
/// TODO: Review implementation - generated with 75% confidence.
/// </summary>
public sealed class CatalogEditPutHandler : IRequestHandler<CatalogEditPutCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public CatalogEditPutHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Result> Handle(CatalogEditPutCommand request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.Edit
        var result = new CatalogEditPutResponseDto();

        if (request.Id == null)
        {
            return Result.Failure("Invalid request");
        }
        CatalogItem catalogItem = _context. /* TODO: Verify this service call transformation */FindCatalogItem(request.Id.Value);
        if (catalogItem == null)
        {
            return Result.Failure("Not found");
        }
        // TODO: Private method AddUriPlaceHolder() is also used by: Edit, Delete
        // Consider extracting to a shared helper class or domain service
        catalogItem.PictureUri = $"/Pics/{catalogItem.Id}.png"; ;
        result.CatalogBrandId = new SelectList(_context.CatalogBrands, "Id", "Brand", catalogItem.CatalogBrandId);
        result.CatalogTypeId = new SelectList(_context.CatalogTypes, "Id", "Type", catalogItem.CatalogTypeId);
        return Result.Success(catalogItem);
    }
}
