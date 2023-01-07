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
using System.ComponentModel;
using System.Collections.Generic;
using Myriadbits.MXF.Identifiers;

namespace Myriadbits.MXF
{
    public class MXFJPEGXSSubDescriptor : MXFSubDescriptor
    {
        private const string CATEGORYNAME = "JPEGXSSubDescriptor";
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey JPEGXSPpih_Key;
        private MXFKey JPEGXSPlev_Key;
        private MXFKey JPEGXSWf_Key;
        private MXFKey JPEGXSHf_Key;
        private MXFKey JPEGXSNc_Key;
        private MXFKey JPEGXSComponentTable_Key;
        private MXFKey JPEGXSCw_Key;
        private MXFKey JPEGXSHsl_Key;
        private MXFKey JPEGXSMaximumBitrate_Key;

        [Category(CATEGORYNAME)]
        public UInt16 JPEGXSPpih { get; set; }

        [Category(CATEGORYNAME)]
        public UInt16 JPEGXSPlev { get; set; }

        [Category(CATEGORYNAME)]
        public UInt16 JPEGXSWf { get; set; }

        [Category(CATEGORYNAME)]
        public UInt16 JPEGXSHf { get; set; }

        [Category(CATEGORYNAME)]
        public byte JPEGXSNc { get; set; }

        [Category(CATEGORYNAME)]
        public byte[] JPEGXSComponentTable { get; set; }

        [Category(CATEGORYNAME)]
        public UInt16? JPEGXSCw { get; set; }

        [Category(CATEGORYNAME)]
        public UInt16? JPEGXSHsl { get; set; }

        [Category(CATEGORYNAME)]
        public UInt32? JPEGXSMaximumBitrate { get; set; }

        public MXFJPEGXSSubDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "JPEG XS Picture SubDescriptor")
        {
        }

        /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("JPEGXSPpih", out ul_key))
                JPEGXSPpih_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSPlev", out ul_key))
                JPEGXSPlev_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSWf", out ul_key))
                JPEGXSWf_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSHf", out ul_key))
                JPEGXSHf_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSNc", out ul_key))
                JPEGXSNc_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSComponentTable", out ul_key))
                JPEGXSComponentTable_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSCw", out ul_key))
                JPEGXSCw_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSHsl", out ul_key))
                JPEGXSHsl_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("JPEGXSMaximumBitrate", out ul_key))
                JPEGXSMaximumBitrate_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            ParamsInitiated = true;
        }

        /// <summary>
        /// Overridden method to process local tags
        /// </summary>
        /// <param name="localTag"></param>
        protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
        {
            if (!ParamsInitiated) InitParms();
            if (localTag.Key != null)
            {
                switch (localTag.Key)
                {
                    case var _ when localTag.Key == JPEGXSPpih_Key : this.JPEGXSPpih = reader.ReadUInt16(); return true;
                    case var _ when localTag.Key == JPEGXSPlev_Key : this.JPEGXSPlev = reader.ReadUInt16(); return true;
                    case var _ when localTag.Key == JPEGXSWf_Key : this.JPEGXSWf = reader.ReadUInt16(); return true;
                    case var _ when localTag.Key == JPEGXSHf_Key : this.JPEGXSHf = reader.ReadUInt16(); return true;
                    case var _ when localTag.Key == JPEGXSNc_Key : this.JPEGXSNc = reader.ReadByte(); return true;
                    case var _ when localTag.Key == JPEGXSComponentTable_Key : this.JPEGXSComponentTable = reader.ReadArray<byte>(reader.ReadByte, localTag.Size); return true;
                    case var _ when localTag.Key == JPEGXSCw_Key : this.JPEGXSCw = reader.ReadUInt16(); return true;
                    case var _ when localTag.Key == JPEGXSHsl_Key : this.JPEGXSHsl = reader.ReadUInt16(); return true;
                    case var _ when localTag.Key == JPEGXSMaximumBitrate_Key : this.JPEGXSMaximumBitrate = reader.ReadUInt32(); return true;
                }
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
