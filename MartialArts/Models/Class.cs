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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //write custom validator to keep this in days of the week
        public string DayOfWeek { get; set; }
        public int StyleId { get; set; }
        public Style Style { get; set; }

        public virtual ICollection<attendance_class> Attendance_Classes { get; set; }
    }
}
