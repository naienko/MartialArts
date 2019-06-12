using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        [Required]
        public int StartingStyle { get; set; }

        [Display(Name = "Styles")]
        [Required]
        public List<int> StudentStyle { get; set; } = new List<int>();
        [Display(Name = "Ranks")]
        [Required]
        public List<int> StudentRank { get; set; } = new List<int>();

        public List<SelectListItem> StylesList;
        public List<SelectListItem> RanksList;
        
        public StudentCreateViewModel(DbSet<Style> styles, DbSet<Rank> ranks)
        {
            StyleSelectFactory(styles);
            RankSelectFactory(ranks);
        }

        public void StyleSelectFactory(DbSet<Style> styles)
        {
            StylesList = styles.Select(li => new SelectListItem
            {
                Text = li.Name,
                Value = li.Id.ToString()
            }).ToList();
            StylesList.Insert(0, new SelectListItem
            {
                Text = "Choose student's starting style",
                Value = "0"
            });
            StylesList.RemoveAt(1);
        }

        public void RankSelectFactory(DbSet<Rank> ranks)
        {
            RanksList = ranks.Select(li => new SelectListItem
            {
                Text = li.Name,
                Value = li.Id.ToString()
            }).ToList();
            RanksList.Insert(0, new SelectListItem
            {
                Text = "Choose student's rank",
                Value = "0"
            });
        }
    }
}
