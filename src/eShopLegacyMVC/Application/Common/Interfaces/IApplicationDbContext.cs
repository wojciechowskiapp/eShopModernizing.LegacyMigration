namespace eShopLegacyMVC.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using eShopLegacyMVC.Models;

/// <summary>
/// Defines the application database context contract for dependency injection.
/// Implemented by the infrastructure layer's DbContext.
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// Gets the DbSet for CatalogBrand entities.
    /// </summary>
    DbSet<CatalogBrand> CatalogBrands { get; }

    /// <summary>
    /// Gets the DbSet for CatalogItem entities.
    /// </summary>
    DbSet<CatalogItem> CatalogItems { get; }

    /// <summary>
    /// Gets the DbSet for CatalogType entities.
    /// </summary>
    DbSet<CatalogType> CatalogTypes { get; }

    /// <summary>
    /// Asynchronously saves all changes made in this context to the database.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
