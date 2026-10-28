using Microsoft.EntityFrameworkCore;
using NTM_TH_Lab01.Models;

namespace NTM_TH_Lab01.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options) { }

    public DbSet<Major> Majors => Set<Major>();
    public DbSet<Learner> Learners => Set<Learner>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Major>().ToTable("Major");
        modelBuilder.Entity<Learner>().ToTable("Learner");
        modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<Enrollment>().ToTable("Enrollment");

        modelBuilder.Entity<Learner>()
            .HasOne(x => x.Major)
            .WithMany(x => x.Learners)
            .HasForeignKey(x => x.MajorID);

        modelBuilder.Entity<Enrollment>()
            .HasOne(x => x.Learner)
            .WithMany(x => x.Enrollments)
            .HasForeignKey(x => x.LearnerID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}