using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Models.Assoc;
using Projet_2022.Models.Entities;

namespace Projet_2022.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region ProductTag
            builder.Entity<ProductTag>().HasKey(pt => new
            {
                pt.ProductId,
                pt.TagId
            });
            builder.Entity<ProductTag>().HasOne(p => p.Product).WithMany(pt => pt.ProductTags).HasForeignKey(t => t.ProductId);
            builder.Entity<ProductTag>().HasOne(t => t.Tag).WithMany(pt => pt.TagProducts).HasForeignKey(p => p.TagId);
            #endregion

            #region  Order
            builder.Entity<Order>().HasOne(p => p.Product).WithMany(p => p.Orders).HasForeignKey(o => o.ProductId);
            builder.Entity<Order>().HasOne(p => p.User).WithMany(p => p.Orders).HasForeignKey(o => o.IdUser);
            #endregion

            #region  productgalleryimage
            builder.Entity<ProductGalleryImage>().HasOne(p => p.Product).WithMany(p => p.ProductGalleryImages).HasForeignKey(o => o.ProductId);
            #endregion

            #region  Product
            builder.Entity<Product>().HasOne(p => p.Brand).WithMany(p => p.Products).HasForeignKey(o => o.IdBrand);
            builder.Entity<Product>().HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(o => o.IdCategory);
            #endregion

            #region  Coupon
            builder.Entity<Coupon>().HasOne(p => p.Order).WithMany(p => p.Coupons).HasForeignKey(o => o.IdOrder);
            #endregion

            #region  Employee
            builder.Entity<Employee>().HasOne(p => p.Country).WithMany(p => p.Employees).HasForeignKey(o => o.IdCountry);
            builder.Entity<Employee>().HasOne(p => p.Job).WithMany(p => p.Employees).HasForeignKey(o => o.IdJob);
            #endregion

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductGalleryImage> productGalleryImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductTag> ProductsTags { get; set; }
    }
}
