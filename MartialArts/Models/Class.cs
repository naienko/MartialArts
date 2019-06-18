using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Day")]
        [Required]
        public int DayOfWeek { get; set; }
        [Required]
        [Display(Name = "Style")]
        public int StyleId { get; set; }
        public Style Style { get; set; }

        public virtual ICollection<attendance_class> Attendance_Classes { get; set; }
    }
}