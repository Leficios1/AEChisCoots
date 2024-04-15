using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = null!;
        [MaxLength(250)]
        public string Email { get; set; } = null!;
        [MaxLength(250)]
        public string Password { get; set; } = null!;
        [MaxLength(12)]
        public string? phone {  get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //Fk
        public int RoleId { get; set; }
        [Url]
        public string? AvatarUrl { get; set; }
        public string? Gender { get; set; }
        public bool status { get; set; }

        //Navigation
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public Role Role { get; set; }

    }
}
