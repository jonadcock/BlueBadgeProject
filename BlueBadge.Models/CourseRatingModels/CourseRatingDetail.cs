using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseRatingModels
{
    public class CourseRatingDetail
    {
        public int CourseRatingId { get; set; }

        public string CourseName { get; set; }

        public DateTime DatePlayed { get; set; }

        public float CourseRatings { get; set; }

        public int CourseId { get; set; }

        public int PlayerId { get; set; }
    }
}
