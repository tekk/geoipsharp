/**
 * Location.cs
 *
 * Copyright (C) 2008 MaxMind Inc.  All Rights Reserved.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */
namespace MaxMind.GeoIP
{

    using System;
    using System.IO;

    /// <summary>
    /// Represents a specific location on the Earths surface
    /// </summary>
    public class Location
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int DmaCode { get; set; }
        public int AreaCode { get; set; }
        public string RegionName { get; set; }
        public int MetroCode { get; set; }

        private static double EARTH_DIAMETER = 2 * 6378.2;
        private static double PI = 3.14159265;
        private static double RAD_CONVERT = PI / 180;

        public double Distance(Location loc)
        {
            double delta_lat, delta_lon;
            double temp;

            double lat1 = Latitude;
            double lon1 = Longitude;
            double lat2 = loc.Latitude;
            double lon2 = loc.Longitude;

            // convert degrees to radians
            lat1 *= RAD_CONVERT;
            lat2 *= RAD_CONVERT;

            // find the deltas
            delta_lat = lat2 - lat1;
            delta_lon = (lon2 - lon1) * RAD_CONVERT;

            // Find the great circle Distance
            temp = Math.Pow(Math.Sin(delta_lat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(delta_lon / 2), 2);
            return EARTH_DIAMETER * Math.Atan2(Math.Sqrt(temp), Math.Sqrt(1 - temp));
        }
    }
}