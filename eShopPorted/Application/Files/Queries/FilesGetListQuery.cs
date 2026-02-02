namespace eShopPorted.Application.Files.Queries;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopPorted.Application.Common;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Models;

/// <summary>
/// Query for Index operation.
/// </summary>
public record FilesGetListQuery : IRequest<Result>;

/// <summary>
/// Handles the FilesGetListQuery query.
/// </summary>
public sealed class FilesGetListHandler : IRequestHandler<FilesGetListQuery, Result>
{
    private readonly IApplicationDbContext _context;

    public FilesGetListHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(FilesGetListQuery request, CancellationToken cancellationToken)
    {
        // Business logic from FilesController.Index
        var brands = await _context.CatalogBrands
        .Select(b => new BrandDTO
        {
            Id = b.Id,
            Brand = b.Brand
        }).ToListAsync(cancellationToken);
        var serializer = new Serializing();
        var data = serializer.SerializeBinary(brands);
        return Result.Success(data);
    }
}
