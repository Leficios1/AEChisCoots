namespace SWP391_BL3W.DTO.Response
{
    public class ProductsResponseDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl {  get; set; }
        public int quantity {  get; set; }
        public decimal price { get; set; }


    }
}
