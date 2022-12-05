using Microsoft.EntityFrameworkCore;

namespace Newsletter.BackendApi.Models
{
    public class ContextDb:DbContext
    {
        public ContextDb(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<NewsLetter> Newsletters { get; set; }
    }
}
