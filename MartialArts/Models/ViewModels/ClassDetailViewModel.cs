using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models.ViewModels
{
    public class ClassDetailViewModel
    {
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public List<Dictionary<DateTime, List<Student>>> sortByDates { get; set; } = new List<Dictionary<DateTime, List<Student>>>();
    }
}
