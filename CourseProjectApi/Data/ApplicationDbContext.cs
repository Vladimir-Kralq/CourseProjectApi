using CourseProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProjectApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; } 
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Enrollment> Enrollments { get; set; } 
        public DbSet<CourseTeacher> CourseTeachers { get; set; } 
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; } 
        public DbSet<Team> Teams { get; set; } 
        public DbSet<TeamMember> TeamMembers { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

          
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.UserId, e.CourseId });

            
            modelBuilder.Entity<CourseTeacher>()
                .HasKey(ct => new { ct.UserId, ct.CourseId });

            
            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.UserId });


            modelBuilder.Entity<Submission>()
                .HasKey(tm => new { tm.AssignmentId, tm.UserId });
        }
    }
}
