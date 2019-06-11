using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MartialArts.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Style")]
        public int StyleId { get; set; }

        public Style Style { get; set; }

        [Required]
        [Display(Name = "Rank")]
        public int RankId { get; set; }

        public Rank Rank { get; set; }

        public virtual ICollection<StudentForms> Students { get; set; }
    }
}
