using Microsoft.EntityFrameworkCore;
using MyWebAppPracting.Models.ModelsMyFirstCodeDatabase;

namespace MyWebAppPracting.Models.ModelsMyFirstCodeDatabase
{
    public partial class myfistcodedatabasedbcontext : DbContext
    {
        public myfistcodedatabasedbcontext(DbContextOptions<myfistcodedatabasedbcontext> options)
            : base(options) { }
        public myfistcodedatabasedbcontext()
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAndStudent> CourseAndStudents { get; set; }
        public DbSet<Gender> Genders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseAndStudent>(entity =>
            {
                entity.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique();
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
