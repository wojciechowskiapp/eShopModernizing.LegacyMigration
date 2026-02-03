namespace eShopLegacyMVC.Application.Brands.Queries;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Application.Common.Extensions;
using eShopLegacyMVC.Models;
using Microsoft.Extensions.Logging;

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
    private readonly ILogger<BrandsGetFormHandler> _logger;

    public BrandsGetFormHandler(IApplicationDbContext context, ILogger<BrandsGetFormHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result> Handle(BrandsGetFormQuery request, CancellationToken cancellationToken)
    {
        // Business logic from BrandsController.Get
        var brands = _context.CatalogBrands;
        var brand = await brands.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (brand == null)
        {
            return Result.Failure("Not found");
        }
        return Result.Success(brand);
    }
}
