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
        public int status {  get; set; }
        public string? statusMessage { get; set; }
        //Navitation 
        public User User { get; set; }
        public ICollection<OrderDetails> OrdersDetails { get; set; }
        [Required]
        public string PaymentName { get; set; }
        public string? NameCustomer { get; set; }
        public string? AddressCustomer { get; set; }
        public string? PhoneCustomer { get; set; }
    }
}
