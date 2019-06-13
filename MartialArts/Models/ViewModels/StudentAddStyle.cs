using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models.ViewModels
{
    public class StudentAddStyle
    {
        public int StudentId { get; set; }

        public int StyleId { get; set; }

        public int RankId { get; set; }

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
