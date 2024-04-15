using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
        //Navigation Property
        public ICollection<Product> Product { get; set; }
    }
}
