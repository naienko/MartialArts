using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MartialArts.Models.ViewModels
{
    public class ClassAttendanceViewModel
    {
        [Display(Name = "Students")]
        public List<int> AllStudents { get; set; } = new List<int>();
        public int ClassId { get; set; }
        public Class Class { get; set; } = new Class();
        [DataType(DataType.Date)]
        public DateTime DateOfClass { get; set; }
    }
}
