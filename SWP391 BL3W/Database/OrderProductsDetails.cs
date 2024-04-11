using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("OrderProductsDetails")]
    public class OrderProductsDetails
    {
        [Key]
        public int Id {  get; set; }
        //Fk
        public int OrderDetailsId {  get; set; }
        public int ProductsDetailsId { get; set; }
        //Navigation
        public OrderDetails OrderDetail { get; set; }
        public ProductsDetails ProductDetail { get; set; }
    }
}
