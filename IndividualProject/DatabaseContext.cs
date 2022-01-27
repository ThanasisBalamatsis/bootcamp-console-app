using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using IndividualProject.Entities;

namespace IndividualProject
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Assignment> assignments { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Trainer> trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.courses)
                .WithMany(e => e.assignments)
                .Map(m => m.ToTable("course_assignment").MapLeftKey("assignment_id").MapRightKey("course_id"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.trainers)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("course_trainer").MapLeftKey("course_id").MapRightKey("trainer_id"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.students)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("student_course").MapLeftKey("course_id").MapRightKey("student_id"));
        }
    }
}
