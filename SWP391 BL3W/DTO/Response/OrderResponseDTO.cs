using SWP391_BL3W.Database;

namespace SWP391_BL3W.DTO.Response
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int status {  get; set; }
        public string? statusMessage { get; set; }  
        public string PaymentName {  get; set; }
        public string? NameCustomer { get; set; }
        public string? AddressCustomer { get; set; }
        public string? PhoneCustomer { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
