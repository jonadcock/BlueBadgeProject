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
        public string PlayerName { get; set; }

        [Required]
        public int ActiveSince { get; set; }

        public override string ToString() => PlayerName;
        }
}
