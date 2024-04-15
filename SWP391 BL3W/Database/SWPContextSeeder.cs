using Microsoft.EntityFrameworkCore;

namespace SWP391_BL3W.Database
{
    public static class SWPContextSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(

               new Role
               {
                   RoleId = 1,
                   RoleName = "Admin"
               },
               new Role
               {
                   RoleId = 2,
                   RoleName = "Customer"
               },
               new Role
               {
                   RoleId = 3,
                   RoleName = "Staff"
               }
               );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Ấm siêu tốc"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Bếp điện từ"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "admin",
                    Email = "admin@gmail.com",
                    Password = "12345",
                    phone = "0321456789",
                    Address = "HCM",
                    DateOfBirth = DateTime.Now,
                    RoleId = 1,
                    AvatarUrl = "https://inkythuatso.com/uploads/thumbnails/800/2023/03/9-anh-dai-dien-trang-inkythuatso-03-15-27-03.jpg",
                    Gender = "Male",
                    status = true
                }
            );
        }
    }
}
