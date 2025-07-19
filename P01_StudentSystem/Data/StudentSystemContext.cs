using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    internal class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Student System;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourse>()
                .HasKey(e => new
                {
                    e.StudentId,
                    e.CourseId

                });
            modelBuilder.Entity<StudentCourse>()
      .HasKey(e => new { e.StudentId, e.CourseId });

            //  Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    Name = "Farouk",
                    PhoneNumber = "0123456789",
                    RegisteredOn = DateTime.Now,
                    Birthday = new DateOnly(1999, 1, 18)
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Mohamed",
                    PhoneNumber = "0112233445",
                    RegisteredOn = DateTime.Now,
                    Birthday = new DateOnly(2000, 6, 15)
                }
            );

            //  Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    Name = "C#",
                    Description = "Course C#",
                    StartDate = new DateOnly(2025, 1, 1),
                    EndDate = new DateOnly(2025, 6, 1),
                    Price = 1000
                },
                new Course
                {
                    CourseId = 2,
                    Name = "C++",
                    Description = "Course C++",
                    StartDate = new DateOnly(2025, 2, 1),
                    EndDate = new DateOnly(2025, 7, 1),
                    Price = 1200
                }
            );

            //  Seed StudentCourse (join table)
            modelBuilder.Entity<StudentCourse>().HasData(
                new { StudentId = 1, CourseId = 1 },
                new { StudentId = 2, CourseId = 1 },
                new { StudentId = 2, CourseId = 2 }
            );

            //  Seed Resources
            modelBuilder.Entity<Resource>().HasData(
                new Resource
                {
                    ResourceId = 1,
                    Name = "Intro Video",
                    Url = "http://test.com/intro-csharp",
                    ResourceType = ResourceType.Video,
                    CourseId = 1
                },
                new Resource
                {
                    ResourceId = 2,
                    Name = "EF Docs",
                    Url = "http://test.com/ef-core-docs",
                    ResourceType = ResourceType.Document,
                    CourseId = 2
                }
            );

            //  Seed Homework
            modelBuilder.Entity<Homework>().HasData(
                new Homework
                {
                    HomeworkId = 1,
                    Content = "C# homework ",
                    ContentType = ContentType.Pdf,
                    SubmissionTime = DateTime.Now,
                    StudentId = 1,
                    CourseId = 1
                },
                new Homework
                {
                    HomeworkId = 2,
                    Content = "C++ homework ",
                    ContentType = ContentType.Zip,
                    SubmissionTime = DateTime.Now,
                    StudentId = 2,
                    CourseId = 2
                }
            );
        }
    }
}
