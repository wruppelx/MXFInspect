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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Myriadbits.MXF
{
    public class MXFGenericStreamDataElement : MXFKLV
    {
        private const string CATEGORYNAME = "Generic Stream Data Element";
        [Category(CATEGORYNAME)]
        public byte DataSignaling { get; set; }

        [Category(CATEGORYNAME)]
        public byte WrappingSignaling { get; set; }

        [Category(CATEGORYNAME)]
        public byte[] Payload { get; set; }

         public MXFGenericStreamDataElement(MXFReader reader, MXFKLV headerKLV)
            : base(headerKLV, "GenericStreamDataElement", KeyType.GenericStreamDataElement)
        {
            this.m_eType = MXFObjectType.Essence;
            this.DataSignaling = this.Key[11];
            this.WrappingSignaling = this.Key[12];
            // Make sure we read at the data position
            reader.Seek(this.DataOffset);
            this.Payload = reader.ReadArray(reader.ReadByte, (int)this.Length);
        }

        public override string ToString()
        {
            return string.Format("Generic Stream Data Element");
        }
    }
}

