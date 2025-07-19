using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public enum ContentType
    {
        Application=0,
        Pdf=1,
        Zip=2
    }
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        [Unicode(false)]
        public string Content { get; set; }=string.Empty;
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }


    }
}
