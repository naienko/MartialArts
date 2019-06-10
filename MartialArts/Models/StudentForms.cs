﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class StudentForms
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int StyleId { get; set; }
        public Style Style { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}
