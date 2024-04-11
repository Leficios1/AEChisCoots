using System.ComponentModel.DataAnnotations;

namespace SWP391_BL3W.DTO.Request
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Url(ErrorMessage = "Url hình ảnh không hợp lệ.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc.")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 0.")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "ID danh mục là bắt buộc.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc.")]

        public List<ProductDetailDTO> Details { get; set; }
    }

    public class ProductDetailDTO
    {
        [Required(ErrorMessage = "Tên chi tiết sản phẩm là bắt buộc.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá trị chi tiết sản phẩm là bắt buộc.")]
        public string Value { get; set; }
    }
}

