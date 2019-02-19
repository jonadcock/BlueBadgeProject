﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class CourseRating
    {
        [Key]
        public int CourseRatingId { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public float CourseRatings { get; set; }
 
        [Required]
        [Display(Name = "Date of Playthrough")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy")]
        public DateTime DatePlayed { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        public virtual Course Course { get; set; }
        public virtual Player Player { get; set; }

    }
}
