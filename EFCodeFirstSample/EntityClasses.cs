using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EFCodeFirstSample
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }

    public class Enrollment
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int ScheduleID { get; set; }
    }

    // dies hier ist eine Annotation um die DB anzupassen
    //[Table("PlannedCourses")]
    public class Schedule
    {
        public int ScheduleID { get; set; }

        // dies hier ist eine Annotation um die DB anzupassen
        //[Column("StartDate")]
        public DateTime Start { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }

    public class Course
    {
        // dies hier ist eine Annotation um die DB anzupassen
        //[Column("KursNr")]
        public int CourseID { get; set; }

        // dies hier ist eine Annotation um die DB anzupassen
        //[Required, MaxLength(120)]
        public string Title { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public List<Schedule> Schedules { get; set; }
    }

    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("KerimTestDB")
        {
            // nach der Entwicklungsphase unbedingt die Klasse DropCreateDatabaseAlways ändern in DropCreateDatabaseIfModelChanges
            // dies hier, ist die Version im Code unbedingt das App.config auch anpassen!!!!!!!
            Database.SetInitializer(new DropCreateDatabaseAlways<SchoolContext>());
        }

        // Dies hier nennt man FluentAPI wird für die Annotationen angewendet
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Klasse 'Course'
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseID)
                .HasColumnName("KursNr");
            modelBuilder.Entity<Course>()
                .Property(c => c.Title)
                .IsRequired();
            modelBuilder.Entity<Course>()
                .Property(c => c.Title)
                .HasMaxLength(120);
            // Klasse 'Schedule'
            modelBuilder.Entity<Schedule>()
                .ToTable("PlannedCourses");
            modelBuilder.Entity<Schedule>()
                .Property(cd => cd.Start)
                .HasColumnName("StartDate");
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}