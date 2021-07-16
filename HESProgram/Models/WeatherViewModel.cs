using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HESProgram.Models
{
    public class WeatherViewModel
    {
        [Required]
        public int WeatherId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public System.DateTime WeatherDate { get; set; }


        [Required]
        [Display(Name = "Wind Speed")]
        public string Wind { get; set; }

        [Required]
        [Display(Name = "Wind Direction")]
        public string WindDirection { get; set; }


        [Required]
        public string Temperature { get; set; }


        [Required]
        public decimal Humidity { get; set; }

        [Required]
        public decimal Precipitation { get; set; }

        [Required]
        [Display(Name = "Cloud Coverage")]
        public string WeatherType { get; set; }
    }
}