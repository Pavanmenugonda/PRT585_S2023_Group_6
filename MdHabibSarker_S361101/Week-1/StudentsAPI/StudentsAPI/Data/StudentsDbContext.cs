using Microsoft.EntityFrameworkCore;
using StudentsAPI.Models;

namespace StudentsAPI.Data
{
    public class StudentsDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasNoKey();
        }
        public StudentsDbContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<Student> Students { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
