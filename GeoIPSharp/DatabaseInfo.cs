/**
 * DatabaseInfo.cs
 *
 * Copyright (C) 2008 MaxMind Inc.  All Rights Reserved.
 * Copyright (C) 2010 GeoIPSharp.   All Rights Reserved.
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

    public class DatabaseInfo
    {
        public const int COUNTRY_EDITION = 1;
        public const int REGION_EDITION_REV0 = 7;
        public const int REGION_EDITION_REV1 = 3;
        public const int CITY_EDITION_REV0 = 6;
        public const int CITY_EDITION_REV1 = 2;
        public const int ORG_EDITION = 5;
        public const int ISP_EDITION = 4;
        public const int PROXY_EDITION = 8;
        public const int ASNUM_EDITION = 9;
        public const int NETSPEED_EDITION = 10;

        private string info;

        /// <summary>
        /// Creates a new DatabaseInfo objectfor the given database info String
        /// </summary>
        /// <param name="info"></param>
        public DatabaseInfo(string info)
        {
            this.info = info;
        }

        public int DatabaseType
        {
            get { return GetDatabaseType(); }
        }

        private int GetDatabaseType()
        {
            if (string.IsNullOrEmpty(info))
            {
                return COUNTRY_EDITION;
            }
            else
            {
                // Get the type code from the database info string and then
                // subtract 105 from the value to preserve compatability with
                // databases from April 2003 and earlier.
                return Convert.ToInt32(info.Substring(4, 7)) - 105;
            }
        }

        /// <summary>
        /// Returns true if the database is the premium version
        /// </summary>
        public bool IsPremium
        {
            get
            {
                return info.IndexOf("FREE") < 0;
            }
        }

        /// <summary>
        /// The date of the database file
        /// </summary>
        public DateTime Date
        {
            get { return GetDate(); }
        }

        private DateTime GetDate()
        {
            for (int i = 0; i < info.Length - 9; i++)
            {
                if (Char.IsWhiteSpace(info[i]) == true)
                {
                    string dateString = info.Substring(i + 1, i + 9);
                    try
                    {
                        return DateTime.ParseExact(dateString, "yyyyMMdd", null);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                    break;
                }
            }
            return DateTime.Now;
        }

        public override string ToString()
        {
            return info;
        }
    }
}