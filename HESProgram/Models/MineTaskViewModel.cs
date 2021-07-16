using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESProgram.Models
{
    public class MineTaskViewModel
    {
        [Required]
        public int taskId { get; set; }

        [Required]
        [Display(Name = "Task Description")]
        public string taskDescription { get; set; }

        [Required]
        [Display(Name = "Respirator")]
        public string Respirator { get; set; }

        [Required]
        [Display(Name = "Medical Monitoring")]
        public string MedicalMonitoring { get; set; }

    }

}