﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class Rank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        //this attribute should contain the length of time a student must wait, 
        //after attaining this rank, before they can test for the next rank,
        //formatted as int string(year || month)
        [Display(Name = "Required Time before Next Test")]
        public string TimeInRank { get; set; }

        [Required]
        [Display(Name = "Style")]
        public int StyleId { get; set; }

        public Style Style { get; set; }

        public virtual ICollection<StudentStyle> Students { get; set; }
    }
}
