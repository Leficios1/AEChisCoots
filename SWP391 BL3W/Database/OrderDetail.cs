using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        //Fk
        public int ProductId { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiredWarranty { get; set; }
        //Navigation
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        //public ICollection<OrderProductsDetails> OrderProductsDetails { get; set; }

    }
}
