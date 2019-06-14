using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models.ViewModels
{
    public class TestAttendanceViewModel
    {
        [Display(Name = "Students")]
        public List<int> AllStudents { get; set; } = new List<int>();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
    }
}
