using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ait.WeatherServer.Core.Enums;

namespace Ait.WeatherServer.Core.Entities
{
    public class Location
    {
        public string LocationName { get; set; }
        public int Temperature { get; set; }
        public CloudSituation CloudSituation { get; set; }
        public WindDirection WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public Location()
        { }
        public Location(string locationName, int temperature, CloudSituation cloudSituation, WindDirection windDirection, int windspeed)
        {
            LocationName = locationName;
            Temperature = temperature;
            CloudSituation = cloudSituation;
            WindDirection = windDirection;
            WindSpeed = windspeed;
        }
    }
}
