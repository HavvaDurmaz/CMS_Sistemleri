using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace App.Data.Entity
{
    public class PostComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public string NameSurName { get; set; }
        public bool IsActive { get; set; }

        public virtual Post Post { get; set; }
    }
}
