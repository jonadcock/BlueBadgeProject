using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseRatingModels
{
    public class CourseRatingCreate
    {
        [Required]
        public float CourseRating { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
