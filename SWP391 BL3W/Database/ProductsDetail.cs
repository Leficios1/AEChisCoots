using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("ProductDetail")]
    public class ProductsDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Value { get; set; } = null!;
        public Product Product { get; set; }

        //Navigation
        //public ICollection<OrderProductsDetails> OrderProductsDetails { get; set; }


    }
}
