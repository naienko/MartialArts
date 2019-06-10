using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class attendance_test
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }
        //did the student pass the test?
        public bool did_pass { get; set; }
    }
}
