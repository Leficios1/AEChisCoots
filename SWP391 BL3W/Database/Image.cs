using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Image")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        // FK
        public int ProductId { get; set; }
        // Navigation
        public Products Product { get; set; }
    }
}
