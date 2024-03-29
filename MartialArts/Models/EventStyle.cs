﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class EventStyle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Required]
        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}
