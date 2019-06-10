using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MartialArts.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsTesting { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string LocationNotes { get; set; }

        public int StaffId { get; set; }

        public Student Staff { get; set; }

        public virtual ICollection<EventStyle> EventStyle { get; set; }
        public virtual ICollection<attendance_test> Attendance_Test { get; set; }

    }
}
