using Microsoft.EntityFrameworkCore;
using MVC_Enrolment_demo.Models.Domain;

namespace MVC_Enrolment_demo.Data
{
    public class MVCDemoDBContext : DbContext
    {
        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {
        }
          
        public DbSet<Employee> Employees { get; set; }
    }
}
