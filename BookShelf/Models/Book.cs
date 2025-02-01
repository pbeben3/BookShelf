using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    [Table("Books", Schema = "Library")]
    public class Book
    {
        public Book() { } 

        public Book(string title, string author, string description, int categoryId)
        {
            Title = title;
            Author = author;
            Description = description;
            CategoryId = categoryId;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [MaxLength(500)] 
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
