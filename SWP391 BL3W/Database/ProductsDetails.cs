using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("ProductDetials")]
    public class ProductsDetails
    {
        [Key]
        public int Id { get; set; }
        //FK
        [Required]
        public int ProductsId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Value { get; set; } = null!;
        public Products Products { get; set; }

        //Navigation
        public ICollection<OrderProductsDetails> OrderProductsDetails { get; set; }


    }
}
