namespace eShopLegacyMVC.Application.Files.Queries;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;

/// <summary>
/// Query for Get operation.
/// </summary>
public record FilesGetQuery : IRequest<Result<HttpResponseMessage>>;

/// <summary>
/// Handles the FilesGetQuery query.
/// </summary>
public sealed class FilesGetHandler : IRequestHandler<FilesGetQuery, Result<HttpResponseMessage>>
{
    private readonly IApplicationDbContext _context;

    public FilesGetHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<HttpResponseMessage>> Handle(FilesGetQuery request, CancellationToken cancellationToken)
    {
        // Business logic from FilesController.Get
        var brands = await _context.CatalogBrands
        .Select(b => new BrandDTO
        {
            Id = b.Id,
            Brand = b.Brand
        }).ToListAsync(cancellationToken);
        var serializer = new Serializing();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(serializer.SerializeBinary(brands))
        };
        return Result.Success(response);
    }
}
