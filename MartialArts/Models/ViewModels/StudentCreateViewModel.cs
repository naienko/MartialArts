using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models.ViewModels
{
    public class StudentCreateViewModel
    {
        public Student Student { get; set; } = new Student();

        [Display(Name = "Styles")]
        [Required]
        public List<int> StudentStyle { get; set; } = new List<int>();
        [Display(Name = "Ranks")]
        [Required]
        public List<int> StudentRank { get; set; } = new List<int>();
    }
}
