using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        //Navigation
        public ICollection<User> users { get; set; }
    }
}
