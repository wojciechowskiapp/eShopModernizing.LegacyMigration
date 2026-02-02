namespace eShopLegacyMVC.Application.Catalog.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;

/// <summary>
/// Command for DeleteConfirmed operation.
/// </summary>
public record CatalogDeleteConfirmedCommand(int Id) : IRequest<Result>;

/// <summary>
/// Handles the CatalogDeleteConfirmedCommand command.
/// </summary>
public sealed class CatalogDeleteConfirmedHandler : IRequestHandler<CatalogDeleteConfirmedCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public CatalogDeleteConfirmedHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CatalogDeleteConfirmedCommand request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.DeleteConfirmed
        CatalogItem catalogItem = _context.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType).FirstOrDefaultAsync(ci => ci.Id == request.Id);
        _context.CatalogItems.Remove(catalogItem);
        await _context.SaveChangesAsync(cancellationToken);
        _context.CatalogItems.Remove(catalogItem);
        return Result.Success();
    }
}
