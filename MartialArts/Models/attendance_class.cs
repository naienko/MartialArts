using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class attendance_class
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public DateTime Date { get; set; }
    }
}
