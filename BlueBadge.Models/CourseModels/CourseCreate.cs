using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseModels
{
    public class CourseCreate
    {
        [Required]
        public string CourseName { get; set; }

        [Required]
        public string LocationCity { get; set; }

        [Required]
        public string LocationState { get; set; }

        [Required]
        public int CourseLength { get; set; }

        [Required]
        public int CoursePar { get; set; }

        public override string ToString() => CourseName;
    }
}
