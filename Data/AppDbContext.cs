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
                pt.IdProduct,
                pt.IdTag
            });
            builder.Entity<ProductTag>().HasOne(p => p.Product).WithMany(pt => pt.ProductTags).HasForeignKey(t => t.IdProduct);
            builder.Entity<ProductTag>().HasOne(t => t.Tag).WithMany(pt => pt.TagProducts).HasForeignKey(p => p.IdTag);
            #endregion

            #region ProductOption
            builder.Entity<ProductOption>().HasKey(po => new
            {
                po.IdProduct,
                po.IdOption
            });
            builder.Entity<ProductOption>().HasOne(p => p.Product).WithMany(po => po.ProductOptions).HasForeignKey(o => o.IdProduct);
            builder.Entity<ProductOption>().HasOne(p=>p.Option).WithMany(po=>po.ProductsOption).HasForeignKey(o => o.IdOption);
            #endregion

            #region Cart
            builder.Entity<Cart>().HasOne(p => p.User).WithMany(p => p.Carts).HasForeignKey(o => o.IdUser);
            #endregion

            #region Gallery Product Option
            builder.Entity<GalleryProductOption>().HasOne(b => b.ProductOption).WithMany(po => po.GalleryProductOptions).HasForeignKey(b => b.IdProductOption);
            #endregion

            #region Option
            builder.Entity<Option>().HasOne(b => b.OptionGroup).WithMany(og => og.Options).HasForeignKey(b => b.IdOptionGroup);
            #endregion

            #region OrderDetails
            builder.Entity<OrderDetails>().HasOne(b => b.Cart).WithMany(c => c.OrderDetailss).HasForeignKey(od => od.IdCart);
            #endregion
            #region Order
            builder.Entity<Order>().HasOne(o => o.Product).WithMany(p => p.Orders).HasForeignKey(o => o.IdProduct);
            #endregion

            #region  productgalleryimage
            builder.Entity<ProductGalleryImage>().HasOne(pgi => pgi.Product).WithMany(p => p.ProductGalleryImages).HasForeignKey(o => o.IdProduct);
            #endregion

            #region  Product
            builder.Entity<Product>().HasOne(p => p.Brand).WithMany(p => p.Products).HasForeignKey(o => o.IdBrand);
            builder.Entity<Product>().HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(o => o.IdCategory);
            #endregion

            base.OnModelCreating(builder);


        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductGalleryImage> ProductGalleryImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductTag> ProductsTags { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<GalleryProductOption> GalleryProductsOptions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionGroup> OptionGroups { get; set; }
        public DbSet<OrderDetails> OrderDetailss { get; set; }
    }
}
