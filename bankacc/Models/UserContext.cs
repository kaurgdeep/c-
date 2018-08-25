using Microsoft.EntityFrameworkCore;
 
namespace bankacc.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
       
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<Person> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Transaction> transactions { get; set; }
    }

}
