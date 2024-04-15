using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Image")]
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        // FK
        public int ProductId { get; set; }
        // Navigation
        public Product Product { get; set; }
    }
}
