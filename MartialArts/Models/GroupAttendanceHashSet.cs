using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class GroupAttendanceHashSet
    {
        public DateTime Key { get; set; }
        public List<attendance_class> Attendees { get; set; } = new List<attendance_class>();
    }
}
