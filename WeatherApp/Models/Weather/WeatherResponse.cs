using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Weahter
{
    public class WeatherResponse
    {
        public string Name { get; set; }

        public Main Main { get; set; }

        public Sys Sys { get; set; }
    }
}