using Microsoft.EntityFrameworkCore;

namespace Movie_Ticketing.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
