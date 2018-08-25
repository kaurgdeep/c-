using Microsoft.EntityFrameworkCore;
 
namespace login_reg.Models
{
    public class LoginContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LoginContext(DbContextOptions<LoginContext> options) : base(options) { }
        public DbSet<Person> users { get; set; }
    }
}
