using Microsoft.EntityFrameworkCore;

namespace MVCDay6.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> departments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CourseResult> courseResults { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=mariam;Initial catalog= mvcday6;Integrated security = true; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
