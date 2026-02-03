namespace eShopLegacyMVC.Application.Brands.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Application.Common;
using eShopLegacyMVC.Application.Common.Interfaces;
using eShopLegacyMVC.Models;
using Microsoft.Extensions.Logging;

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
    private readonly ILogger<BrandsDeleteHandler> _logger;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTime _dateTime;

    public BrandsDeleteHandler(
        IApplicationDbContext context,
        ILogger<BrandsDeleteHandler> logger,
        ICurrentUserService currentUser,
        IDateTime dateTime)
    {
        _context = context;
        _logger = logger;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }

    public async Task<Result> Handle(BrandsDeleteCommand request, CancellationToken cancellationToken)
    {
        // Business logic from BrandsController.Delete
        var brandToDelete = await _context.CatalogBrands.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (brandToDelete == null)
        {
            return Result.Success(ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound)));
        }
        return Result.Success(ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK)));
    }
}
