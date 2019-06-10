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
        public int StyleId { get; set; }

        public Style Style { get; set; }

        [Required]
        public int RankId { get; set; }

        public Rank Rank { get; set; }
    }
}
