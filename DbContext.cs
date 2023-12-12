using _017_web_Ass2.Models;
using Microsoft.EntityFrameworkCore;

namespace _017_web_Ass2.Context
{
    public class DbContext
    {
        
   public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<ModelClasses> Students { get; set; }
        public DbSet<ModelClasses> Classs { get; set; }
        public DbSet<ModelClasses> Facultys { get; set; }
        public DbSet<ModelClasses> Enrolleds { get; set; }
    }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships

        modelBuilder.Entity<Enrolled>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Enrolled>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.Sid);

        modelBuilder.Entity<Enrolled>()
            .HasOne(e => e.Class)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.Cid);

        modelBuilder.Entity<Class>()
            .HasOne(c => c.Faculty)
            .WithMany(f => f.Classes)
            .HasForeignKey(c => c.Fid);
    }
}
}
