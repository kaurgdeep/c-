using Microsoft.EntityFrameworkCore;
 
namespace wedplan.Models
{
    public class WedContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WedContext(DbContextOptions<WedContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
         public DbSet<Wedding> weddings { get; set; }
          public DbSet<Guest> guests { get; set; }
        public object User { get; internal set; }
    }
}
