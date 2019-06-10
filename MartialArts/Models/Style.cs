﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class Style
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentForms> Forms { get; set; }
        public virtual ICollection<StudentStyle> Students { get; set; }
        public virtual ICollection<EventStyle> Events { get; set; }
    }
}
