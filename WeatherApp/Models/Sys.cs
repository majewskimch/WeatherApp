using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class Sys
    {
        public string Country { get; set; }

        public int Sunrise { get; set; }

        public int Sunset { get; set; }
    }
}