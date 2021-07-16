using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESProgram.Models
{
    public class AnalysesViewModel
    {
        [Required]
        [Display(Name = "AnalysisId")]
        public int AnalysisId { get; set; }

        [Required]
        [Display(Name = "Method")]
        public string Method { get; set; }

        [Required]
        [Display(Name = "Air Contaminant")]
        public string AirContaminant { get; set; }

        [Display(Name = "PEL (Permissible Exposure Limit")]
        public decimal? PEL { get; set; }

        [Display(Name = "STEL(Short Term Exposure Limit)")]
        public decimal? STEL { get; set; }

        [Display(Name = "Ceiling Limit")]
        public decimal? CeilingLimit { get; set; }

        [Display(Name = "Action Level")]
        public decimal? ActionLevel { get; set; }

        [Display(Name = "NIOSH Recommended Exposure Limit")]
        public decimal? REL { get; set; }

        [Display(Name = "ACGIH Threshold Limit Value")]
        public decimal? TLV { get; set; }

        [Display(Name = "ACGIH Short Term Exposure Limit")]
        public decimal? TLVST { get; set; }

        [Display(Name = "ACGIH Ceiling Limit")]
        public decimal? TLVC { get; set; }

        [Display(Name = "NIOSH ceiling Limit")]
        public decimal? RELC { get; set; }

        [Display(Name = "NIOSH Short Term Exposure Limit")]
        public decimal? RELST { get; set; }


    }
}