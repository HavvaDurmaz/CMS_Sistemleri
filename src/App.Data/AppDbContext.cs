using App.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostComment> PostComment { get; set; }
        public DbSet<User> User { get; set; }
    }
}
