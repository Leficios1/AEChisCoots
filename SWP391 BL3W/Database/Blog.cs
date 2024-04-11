using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title {  get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        [Url]
        public string ImageUrl {  get; set; }
        //Fk
        public int UserId { get; set; }
        //Navigation
        public User User { get; set; }
    }
}
