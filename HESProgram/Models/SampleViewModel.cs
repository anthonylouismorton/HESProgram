using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HESProgram.Models
{
    public class SampleViewModel
    {
        [Required]
        public int SampleId { get; set; }

        /*[Required]
        public int EmployeeId { get; set; }*/

        [Required]
        [Display(Name = "Sample ID")]
        public string FieldSampleId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public System.DateTime Date { get; set; }

        [Required]
        [Display(Name = "Flow Rate(LPM)")]
        public decimal LPM { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public Nullable<TimeSpan> EndTime { get; set; }

        [Display(Name = "Field Notes")]
        public string FieldNotes { get; set; }

        [Display(Name = "Notification Letter")]
        public string NotificationLetter { get; set; }

        [Display(Name = "Task")]
        public int taskId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
 
    }
}