using SWP391_BL3W.Database;
using static System.Net.Mime.MediaTypeNames;

namespace SWP391_BL3W.DTO.Response
{
    public class ProductDetailsResponseDTO
    {
        public ProductDTOs Products { get; set; }
        public List<ProductsDetailDTO> Details { get; set; }
        public List<ImageDTOs> Images { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
    }

    public class ProductDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int WarrantyPeriod { get; set; }
        public int CategoryID { get; set; }
    }

    public class ProductsDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ImageDTOs
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }

    public class ReviewDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }

}
