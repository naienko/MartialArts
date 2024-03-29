﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models.ViewModels
{
    public class EventCreateViewModel
    {
        public Event Event { get; set; } = new Event();

        [Display(Name = "Styles")]
        [Required]
        public List<int> EventStyle { get; set; } = new List<int>();
    }
}
