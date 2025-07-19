using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [MaxLength(80)]
        [Unicode]      
        public string Name { get; set; } = string.Empty;
        [Unicode]
        public string? Description { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal Price { get; set; }

        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<Student>? Students { get; set; } = new List<Student>();
        public ICollection<Homework>? Homeworks { get; set; } = new List<Homework>();
        public ICollection<Resource>? Resources { get; set; } = new List<Resource>();



    }
}
