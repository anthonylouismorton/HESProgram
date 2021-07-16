using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESProgram.Models
{
    public class SampleResultViewModel
    {
        [Required]
        [Display(Name = "SampleResultId")]
        public int SampleResults { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "Sample ID")]
        public string SampleId { get; set; }

        [Required]
        [Display(Name = "AirContaminant")]
        public string AnalysisId { get; set; }

        [Required]
        [Display(Name = "Sample")]
        public string Sample { get; set; }

        [Required]
        [Display(Name = "Sample Result")]
        public string SampleWithAir { get; set; }

        [Display(Name = "TWA (Time Weighted Average)")]
        public decimal EmployeeTWA { get; set; }

        [Display(Name = "Brief and Scala")]
        public decimal BriefAndScala { get; set; }

        [Required]
        [Display(Name = "Shift Length")]
        public decimal HoursWorked { get; set; }
    }
}