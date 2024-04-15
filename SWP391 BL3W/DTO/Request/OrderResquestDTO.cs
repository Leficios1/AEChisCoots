namespace SWP391_BL3W.DTO.Request
{
    public class OrderResquestDTO
    {
        public List<OrderDetail> OrderDetail { get; set; }
        public DateTime OrderDate { get; set; }
        //public decimal TotalPrice { get; set; }
        public int status { get; set; }
        //public string? statusMessage { get; set; }
        public string PaymentName { get; set; }
        public string? NameCustomer { get; set; }
        public string? AddressCustomer { get; set; }
        public string? PhoneCustomer { get; set; }
        public int UserId { get; set; }
    }
    public class OrderDetail
    {
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiredWarranty { get; set; }
    }
}
    