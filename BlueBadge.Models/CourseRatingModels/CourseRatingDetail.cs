﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseRatingModels
{
    public class CourseRatingDetail
    {
        public int CourseRatingId { get; set; }

        public float CourseRatings { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy")]
        public DateTime DatePlayed { get; set; }

        public int PlayerId { get; set; }

    }
}
