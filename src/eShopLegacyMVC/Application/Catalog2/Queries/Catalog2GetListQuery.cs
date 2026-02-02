namespace eShopLegacyMVC.Application.Catalog2.Queries;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;

/// <summary>
/// Query for Index operation.
/// </summary>
public record Catalog2GetListQuery : IRequest<Result>;

/// <summary>
/// Handles the Catalog2GetListQuery query.
/// </summary>
public sealed class Catalog2GetListHandler : IRequestHandler<Catalog2GetListQuery, Result>
{
    private readonly IApplicationDbContext _context;

    public Catalog2GetListHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Result> Handle(Catalog2GetListQuery request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController2.Index
        return Result.Success(new { Message = "Hello World!" });
    }
}
