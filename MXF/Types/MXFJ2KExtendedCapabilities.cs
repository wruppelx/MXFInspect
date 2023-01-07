#region license
//
// MXF - Myriadbits .NET MXF library. 
// Read MXF Files.
// Copyright (C) 2015 Myriadbits, Jochem Bakker
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// For more information, contact me at: info@myriadbits.com
//
#endregion

using System;

namespace Myriadbits.MXF
{
    //namespace http://www.smpte-ra.org/reg/2003/2012 	
    public class MXFJ2KExtendedCapabilities
    {
        public UInt32 Pcap { get; set; }
        public UInt16[] Ccapi { get; set; }
        public byte ComponentSize { get; set; }

        public override string ToString()
        {
            string ccapi_string = "";
            for (int i = 0; i < Ccapi.Length; i++) ccapi_string += Ccapi[i].ToString() + " ";
            return string.Format("(Pcap: 0x{0:X} Ccapi[]: {1})", Pcap, ccapi_string);
        }
    }
}
