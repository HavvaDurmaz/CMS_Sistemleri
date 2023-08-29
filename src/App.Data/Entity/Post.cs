using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Title { get; set; }
        public string? Content  { get; set; }
        public int CategoryId { get; set; }
        public string PostImage { get; set; }
        public ICollection<PostComment> PostComment { get; set; }
        public Category Category { get; set; }
    }
}
