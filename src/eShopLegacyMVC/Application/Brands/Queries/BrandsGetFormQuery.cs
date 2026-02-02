namespace eShopLegacyMVC.Application.Brands.Queries;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;

/// <summary>
/// Query for Get operation.
/// Generated with 80% confidence from BrandsController.Get.
/// </summary>
public record BrandsGetFormQuery(int Id) : IRequest<Result>;

/// <summary>
/// Handles the BrandsGetFormQuery query.
/// </summary>
public sealed class BrandsGetFormHandler : IRequestHandler<BrandsGetFormQuery, Result>
{
    private readonly IApplicationDbContext _context;

    public BrandsGetFormHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Result> Handle(BrandsGetFormQuery request, CancellationToken cancellationToken)
    {
        // Business logic from BrandsController.Get
        var brands = _context.CatalogBrands;
        var brand = brands.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (brand == null)
        {
        return Result.Failure("Not found");
        }
        return Result.Success(brand);
    }
}
