using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseModels
{
    public class CourseEdit
    {
        [Required]
        public int CourseId { get; set; }

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
    }
}
