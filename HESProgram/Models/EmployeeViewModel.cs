using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESProgram.Models
{
    public class EmployeeViewModel
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Employee Number")]
        public int EmployeeNumber { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Department { get; set; }


        [Required]
        [Display(Name = "Job Title")]
        public string Title { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
    }
}