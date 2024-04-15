using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //Fk
        public int OrderID { get; set; }
        public int OrderProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiredWarranty { get; set; }
        //Navigation
        public Order Order { get; set; }
        //public Products Products { get; set; }
        public ICollection<OrderProductsDetails> OrderProductsDetails { get; set; }

    }
}
