using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        [Unicode]
        public string Name { get; set; } = string.Empty;
        [Unicode(false)]
        [MaxLength(10)]
        [MinLength(10)]
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateOnly? Birthday { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<Course>? Courses { get; set; } = new List<Course>();
        public ICollection<Homework>? Homeworks { get; set; } = new List<Homework>();

    }
}
