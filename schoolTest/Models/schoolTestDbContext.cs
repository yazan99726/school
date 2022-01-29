using Microsoft.EntityFrameworkCore;
using schoolTest.ViewModel;

namespace schoolTest.Models
{
    public class schoolTestDbContext:DbContext
    {
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<LoginAll> LoginAlls { get; set; }
        public DbSet<News> News { get; set; }

        public schoolTestDbContext(DbContextOptions<schoolTestDbContext> options) : base(options)
        {

        }

        public DbSet<schoolTest.ViewModel.NewsViewModel> NewsViewModel { get; set; }


    }
}
