using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartialArts.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of First Class Attended")]
        public DateTime FirstClass { get; set; }

        public int InternalRankId { get; set; }

        [Required]
        public virtual ICollection<StudentStyle> Styles { get; set; }
        public virtual ICollection<StudentForms> Forms { get; set; }
        public virtual ICollection<attendance_test> Attendance_Test { get; set; }
        public virtual ICollection<attendance_class> Attendance_Classes { get; set; }
    }
}
