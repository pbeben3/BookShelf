using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    [Table("Categories", Schema = "Library")]
    public class Category
    {
        public Category() { }

        public Category(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

