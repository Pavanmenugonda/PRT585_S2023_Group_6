using Microsoft.EntityFrameworkCore;
using Web_API_tut_1.Models;

namespace Web_API_tut_1.Data
{
    public class ContactAPIDbContext : DbContext
    {
        public ContactAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
