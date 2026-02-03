namespace eShopPorted.Application.Files.Queries;

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
public record FilesGetListQuery : IRequest<Result>;

/// <summary>
/// Handles the FilesGetListQuery query.
/// </summary>
public sealed class FilesGetListHandler : IRequestHandler<FilesGetListQuery, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<FilesGetListHandler> _logger;

    public FilesGetListHandler(IApplicationDbContext context, ILogger<FilesGetListHandler> logger)
    {
        _context = context;
        _logger = logger;
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
