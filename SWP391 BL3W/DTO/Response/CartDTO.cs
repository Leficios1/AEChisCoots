namespace SWP391_BL3W.DTO.Response
{
    public class CartDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
