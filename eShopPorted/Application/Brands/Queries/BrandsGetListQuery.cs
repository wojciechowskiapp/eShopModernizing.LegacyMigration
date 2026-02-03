namespace eShopPorted.Application.Brands.Queries;

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
public record BrandsGetListQuery : IRequest<Result>;

/// <summary>
/// Handles the BrandsGetListQuery query.
/// </summary>
public sealed class BrandsGetListHandler : IRequestHandler<BrandsGetListQuery, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<BrandsGetListHandler> _logger;

    public BrandsGetListHandler(IApplicationDbContext context, ILogger<BrandsGetListHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<Result> Handle(BrandsGetListQuery request, CancellationToken cancellationToken)
    {
        // Business logic from BrandsController.Index
        var brands = _context.CatalogBrands;
        return Result.Success(brands);
    }
}
