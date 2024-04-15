using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Fk
        public int UserId { get; set; }
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        //Navigation
        public User User { get; set; }
        public Products Products { get; set; }
    }
}
