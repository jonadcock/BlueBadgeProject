﻿using System;
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
        [RangeAttribute (1, 5, ErrorMessage = "Please enter a number between 1 and 5.")]
        [Display(Name = "Course Rating")]
        public float CourseRatings { get; set; }

        [Required]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Date of Playthough")]
        public DateTime DatePlayed { get; set; }

        [Required]
        [Display(Name = "Player ID")]
        public int PlayerId { get; set; }
    }
}
