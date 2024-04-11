using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_BL3W.Database
{
    [Table("CategoryBlog")]
    public class CategoryBlog
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        //Navigation
        public ICollection<Blog>blogs { get; set; }
    }
}
