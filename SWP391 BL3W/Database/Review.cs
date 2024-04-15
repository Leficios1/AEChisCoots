using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id {  get; set; }
        [Required]
        public int UserId {  get; set; }
        [Required]
        public int ProductId {  get; set; }
        [Required]
        public string Comment { get; set; }
        public int Rating { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
