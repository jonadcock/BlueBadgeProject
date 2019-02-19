﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseRatingModels
{
    public class CourseRatingEdit
    {
        [Required]
        public int CourseRatingId { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        [RangeAttribute(1, 5, ErrorMessage = "Please enter a number between 1 and 5.")]
        public float CourseRatings { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy")]
        public DateTime DatePlayed { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }
    }
}