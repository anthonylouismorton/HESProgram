using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESProgram.Models
{
    public class LabReportViewModel
    {
        [Required]
        public int LabReportId { get; set; }

        [Required]
        [Display(Name = "Report Number")]
        public int ReportNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public System.DateTime ReportDate { get; set; }

        [Required]
        public int SampleId { get; set; }

        [Required]
        [Display(Name = "Report Number")]
        public int Air{ get; set; }

    }
}