namespace eShopPorted.Application.Brands.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopPorted.Application.Common;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Models;

/// <summary>
/// Command for Delete operation.
/// Generated with 80% confidence from BrandsController.Delete.
/// </summary>
public record BrandsDeleteCommand(int Id) : IRequest<Result>;

/// <summary>
/// Handles the BrandsDeleteCommand command.
/// </summary>
public sealed class BrandsDeleteHandler : IRequestHandler<BrandsDeleteCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public BrandsDeleteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Result> Handle(BrandsDeleteCommand request, CancellationToken cancellationToken)
    {
        // Business logic from BrandsController.Delete
        var brandToDelete = _context.CatalogBrands.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (brandToDelete == null)
        {
            return Result.Failure("Not found");
        }
        return Result.Success();
    }
}
