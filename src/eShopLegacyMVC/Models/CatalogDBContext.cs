using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using eShopLegacyMVC.Models.Infrastructure;

namespace eShopLegacyMVC.Models
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options)
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
            ConfigureCatalogType(builder.Entity<CatalogType>());
            ConfigureCatalogBrand(builder.Entity<CatalogBrand>());
            ConfigureCatalogItem(builder.Entity<CatalogItem>());
            base.OnModelCreating(builder);
        }

        void ConfigureCatalogType(EntityTypeConfiguration<CatalogType> builder)
        {
            builder.ToTable("CatalogType");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).IsRequired();
            builder.Property(cb => cb.Type).IsRequired().HasMaxLength(100);
        }

        void ConfigureCatalogBrand(EntityTypeConfiguration<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).IsRequired();
            builder.Property(cb => cb.Brand).IsRequired().HasMaxLength(100);
        }

        void ConfigureCatalogItem(EntityTypeConfiguration<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            builder.Property(ci => ci.Name).IsRequired().HasMaxLength(50);
            builder.Property(ci => ci.Price).IsRequired();
            builder.Property(ci => ci.PictureFileName).IsRequired();
            builder.Ignore(ci => ci.PictureUri);
            builder.HasOne(ci => ci.CatalogBrand).WithMany().HasForeignKey(ci => ci.CatalogBrandId).IsRequired(true);
            builder.HasOne(ci => ci.CatalogType).WithMany().HasForeignKey(ci => ci.CatalogTypeId).IsRequired(true);
        }
    }
}