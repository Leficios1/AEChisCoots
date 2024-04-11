using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        //Fk
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        //Navitation 
        public User User { get; set; }
        public ICollection<OrderDetails> OrdersDetails { get; set; }
        [Required]
        public string PaymentName { get; set; }
    }
}
