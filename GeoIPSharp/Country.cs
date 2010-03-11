/**
 * Country.cs
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

    public class Country
    {

        private string code;
        private string name;

        /**
         * Creates a new Country.
         *
         * @param code the country code.
         * @param name the country name.
         */
        public Country(string code, string name)
        {
            this.code = code;
            this.name = name;
        }
        /**
          * Returns the ISO two-letter country code of this country.
          *
          * @return the country code.
          */
        public string Code
        {
            get
            {
                return code;
            }
        }

        /**
         * Returns the name of this country.
         *
         * @return the country name.
         */
        public string Name
        {
            get
            {
                return name;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Code, Name);
        }
    }
}