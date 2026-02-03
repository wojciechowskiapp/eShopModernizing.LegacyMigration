namespace eShopPorted.Application.Catalog.Queries;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopPorted.Application.Common;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Application.Common.Extensions;
using eShopPorted.Models;
using Microsoft.Extensions.Logging;

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
    private readonly ILogger<CatalogGetListHandler> _logger;

    public CatalogGetListHandler(IApplicationDbContext context, ILogger<CatalogGetListHandler> logger)
    {
        _context = context;
        _logger = logger;
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
        ChangeUriPlaceholder(paginatedItems.Data);
        return Result.Success(paginatedItems);
    }

    /// <summary>
    /// Private helper method migrated from controller.
    /// TODO: Review and adapt as needed for handler context.
    /// </summary>
    private void ChangeUriPlaceholder(IEnumerable<CatalogItem> items)
    {
        foreach (var catalogItem in items)
        {
            AddUriPlaceHolder(catalogItem);
        }
    }
}
