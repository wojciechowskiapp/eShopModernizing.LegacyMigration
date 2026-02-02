namespace eShopPorted.Application.Brands.Queries;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopPorted.Application.Common;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Models;

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

    public BrandsGetListHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Result> Handle(BrandsGetListQuery request, CancellationToken cancellationToken)
    {
        // Business logic from BrandsController.Index
        var brands = _context.CatalogBrands;
        return Result.Success(brands);
    }
}
