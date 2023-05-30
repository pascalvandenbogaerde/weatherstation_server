using System;
using System.Collections.Generic;
using Ait.WeatherServer.Core.Entities;
using Ait.WeatherServer.Core.Enums;

namespace Ait.WeatherServer.Core.Services
{
    public class LocationService
    {
        public List<Location> Locations { get; private set; }
        public LocationService()
        {
            Locations = new List<Location>();
        }
        public void AddObservation(Location location)
        {
            bool found = false;
            foreach (Location loc in Locations)
            {
                if (loc.LocationName == location.LocationName)
                {
                    found = true;
                    loc.LocationName = location.LocationName;
                    loc.Temperature = location.Temperature;
                    loc.CloudSituation = location.CloudSituation;
                    loc.WindDirection = location.WindDirection;
                    loc.WindSpeed = location.WindSpeed;
                    break;
                }
            }
            if (!found)
            {
                Locations.Add(location);
            }
        }
        public void RemoveLocation(string locationName)
        {            
            foreach (Location location in Locations)
            {
                if (location.LocationName == locationName)
                {
                    Locations.Remove(location);
                }
            }
        }
    }
}
