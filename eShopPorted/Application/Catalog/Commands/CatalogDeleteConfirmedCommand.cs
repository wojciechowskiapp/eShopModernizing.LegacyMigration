namespace eShopPorted.Application.Catalog.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopPorted.Application.Common;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Models;
using Microsoft.Extensions.Logging;

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
    private readonly ILogger<CatalogDeleteConfirmedHandler> _logger;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTime _dateTime;

    public CatalogDeleteConfirmedHandler(
        IApplicationDbContext context,
        ILogger<CatalogDeleteConfirmedHandler> logger,
        ICurrentUserService currentUser,
        IDateTime dateTime)
    {
        _context = context;
        _logger = logger;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }

    public async Task<Result> Handle(CatalogDeleteConfirmedCommand request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.DeleteConfirmed
        CatalogItem catalogItem = await _context.CatalogItems
        .Include(c => c.CatalogBrand)
        .Include(c => c.CatalogType)
        .FirstOrDefaultAsync(ci => ci.Id == request.Id);
        _context.CatalogItems.Remove(catalogItem);
        await _context.SaveChangesAsync(cancellationToken);
        _context.CatalogItems.Remove(catalogItem);
        return Result.Success();
    }
}
