using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public enum ResourceType
    {
        Video = 0,
        Presentation = 1,
        Document = 2,
        Other = 3
    }


    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        [MaxLength(50)]
        [Unicode]
        public string Name { get; set; } = string.Empty;
        [Unicode(false)]
        public string? Url { get; set; } = string.Empty;
        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
