using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class StudentRegistryDbContext :DbContext
    {
        public DbSet<Student> Students { get; set; } 
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public StudentRegistryDbContext(DbContextOptions<StudentRegistryDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(a => a.StudentId);

            modelBuilder.Entity<Mark>()
            .HasOne(m => m.Student)
            .WithMany(s => s.Marks)
            .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId);
        }
    }
}
