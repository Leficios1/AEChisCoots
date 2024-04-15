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
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductsDetail> ProductsDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        //public DbSet<OrderProductsDetails> OrderProductsDetails { get; set; }
        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SWPContextSeeder.Seed(modelBuilder);
        }
    }
}
