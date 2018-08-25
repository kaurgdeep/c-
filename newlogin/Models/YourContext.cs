using Microsoft.EntityFrameworkCore;
 
namespace newlogin.Models
{
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
        public DbSet<User> users {get; set;}
        public DbSet<Like> likes {get; set;}
        public DbSet<Idea> ideas {get; set;}
    }
}
