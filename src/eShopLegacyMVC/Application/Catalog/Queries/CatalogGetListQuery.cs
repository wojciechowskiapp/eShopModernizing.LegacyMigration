namespace eShopLegacyMVC.Application.Catalog.Queries;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;

/// <summary>
/// Query for Index operation.
/// </summary>
public record CatalogGetListQuery(
    int PageIndex,
    int PageSize = 10
) : IRequest<Result>;

/// <summary>
/// Handles the CatalogGetListQuery query.
/// </summary>
public sealed class CatalogGetListHandler : IRequestHandler<CatalogGetListQuery, Result>
{
    private readonly IApplicationDbContext _context;

    public CatalogGetListHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CatalogGetListQuery request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.Index
        var totalItems = await _context.CatalogItems.LongCountAsync(cancellationToken);
        var itemsOnPage = await _context.CatalogItems
        .Include(c => c.CatalogBrand)
        .Include(c => c.CatalogType)
        .OrderBy(c => c.Id)
        .Skip(request.PageSize * request.PageIndex)
        .Take(request.PageSize)
        .ToListAsync(cancellationToken);
        var paginatedItems = new PaginatedItemsViewModel<CatalogItem>(
        request.PageIndex, request.PageSize, totalItems, itemsOnPage);
        (foreach (var catalogItem in paginatedItems.Data)
        {
        AddUriPlaceHolder(catalogItem);
        });
        return Result.Success(paginatedItems);
    }
}
