using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.PlayerModels
{
    public class PlayerCreate
    {
        [Required]
        [Display(Name = "Player ID")]
        public string PlayerName { get; set; }

        [Required]
        [Display(Name = "Player Name")]
        public int ActiveSince { get; set; }

        [Display(Name = "Active Since")]
        public override string ToString() => PlayerName;
        }
}
