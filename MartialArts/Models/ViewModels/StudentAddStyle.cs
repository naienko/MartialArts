using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models.ViewModels
{
    public class StudentAddStyle
    {
        public int StudentId { get; set; }

        [Display(Name = "Style")]
        public int StyleId { get; set; }

        [Display(Name = "Rank")]
        public int RankId { get; set; }

        [Display(Name = "Forms")]
        public List<int> FormsList { get; set; } = new List<int>();

        public List<SelectListItem> StylesList;

        public StudentAddStyle() { }

        public StudentAddStyle(DbSet<Style> styles)
        {
            StyleSelectFactory(styles);
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
                Text = "Choose student's style",
                Value = "0"
            });
            StylesList.RemoveAt(1);
        }
    }
}
