namespace eShopLegacyMVC.Application.Catalog2.Queries;

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
/// Query for Index operation.
/// </summary>
public record Catalog2GetListQuery : IRequest<Result>;

/// <summary>
/// Handles the Catalog2GetListQuery query.
/// </summary>
public sealed class Catalog2GetListHandler : IRequestHandler<Catalog2GetListQuery, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<Catalog2GetListHandler> _logger;

    public Catalog2GetListHandler(IApplicationDbContext context, ILogger<Catalog2GetListHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<Result> Handle(Catalog2GetListQuery request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController2.Index
        return Result.Success(new { Message = "Hello World!" });
    }
}
