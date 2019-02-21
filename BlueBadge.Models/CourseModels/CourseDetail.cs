using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseModels
{
    public class CourseDetail
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string LocationCity { get; set; }

        public string LocationState { get; set; }

        public int CourseLength { get; set; }

        public int CoursePar { get; set; }

        public float CourseRating { get; set; }
    }
}
