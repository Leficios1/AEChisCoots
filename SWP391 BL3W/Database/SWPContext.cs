using Microsoft.EntityFrameworkCore;

namespace SWP391_BL3W.Database
{
    public class SWPContext : DbContext
    {
        public SWPContext()
        {

        }
        public SWPContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductsDetails> ProductsDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<OrderProductsDetails> OrderProductsDetails { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
