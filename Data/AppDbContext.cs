using HuynhTanLoc_K2023_THIGK.Entity;
using Microsoft.EntityFrameworkCore;

namespace HuynhTanLoc_K2023_THIGK.Data
{
    public class AppDbContext : DbContext
    {
        internal object Course;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CourseEntity>()
                .HasMany(c => c.Enrollments)
                .WithOne(t => t.CourseEntity)
                .HasForeignKey(t => t.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
