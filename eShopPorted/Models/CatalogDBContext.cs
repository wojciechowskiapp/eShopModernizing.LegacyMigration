using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace eShopPorted.Models
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions options) : base(options)
        {
            // TODO: EF6 had lazy loading enabled by default
            // To enable in EF Core, add to Program.cs:
            // services.AddDbContext<CatalogDBContext>(options =>
            //     options.UseLazyLoadingProxies()
            //            .UseSqlServer(connectionString));
            // Requires: Microsoft.EntityFrameworkCore.Proxies package
            // Note: Navigation properties must be virtual
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
