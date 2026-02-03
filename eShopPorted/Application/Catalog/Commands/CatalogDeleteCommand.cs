namespace eShopPorted.Application.Catalog.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopPorted.Application.Common;
using eShopPorted.Application.Common.Interfaces;
using eShopPorted.Models;
using Microsoft.Extensions.Logging;

/// <summary>
/// Command for Delete operation.
/// Generated with 80% confidence from CatalogController.Delete.
/// </summary>
public record CatalogDeleteCommand(int? Id) : IRequest<Result>;

/// <summary>
/// Handles the CatalogDeleteCommand command.
/// </summary>
public sealed class CatalogDeleteHandler : IRequestHandler<CatalogDeleteCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CatalogDeleteHandler> _logger;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTime _dateTime;

    public CatalogDeleteHandler(
        IApplicationDbContext context,
        ILogger<CatalogDeleteHandler> logger,
        ICurrentUserService currentUser,
        IDateTime dateTime)
    {
        _context = context;
        _logger = logger;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }

    public Task<Result> Handle(CatalogDeleteCommand request, CancellationToken cancellationToken)
    {
        // Business logic from CatalogController.Delete
        if (request.Id == null)
        {
            return Result.Failure("Invalid request");
        }
        CatalogItem catalogItem = _context. /* TODO: Verify this service call transformation */FindCatalogItem(request.Id.Value);
        if (catalogItem == null)
        {
            return Result.Failure("Not found");
        }
        AddUriPlaceHolder(catalogItem);
        return Result.Success(catalogItem);
    }

    /// <summary>
    /// Private helper method migrated from controller.
    /// TODO: Review and adapt as needed for handler context.
    /// </summary>
    private void AddUriPlaceHolder(CatalogItem item)
    {
        item.PictureUri = $"/Pics/{item.Id}.png";
    }
}
