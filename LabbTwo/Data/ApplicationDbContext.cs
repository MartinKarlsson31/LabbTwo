using LabbTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace LabbTwo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolConnection> SchoolConnections { get; set;}
        public DbSet<LabbTwo.Models.SearchViewModel> SearchViewModel { get; set; } = default!;
    }
}
