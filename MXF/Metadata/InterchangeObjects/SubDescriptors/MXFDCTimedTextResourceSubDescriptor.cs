#region license
//
// MXF - Myriadbits .NET MXF library. 
// Read MXF Files.
// Copyright (C) 2023 Wolfgang Ruppel
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
    public class MXFDCTimedTextResourceSubDescriptor : MXFSubDescriptor
    {
        private const string CATEGORYNAME = "DCTimedTextResourceSubDescriptor";
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey AncillaryResourceID_Key;
        private MXFKey MIMEType_Key;
        private MXFKey EssenceStreamID_Key;

        [Category(CATEGORYNAME)]
        public MXFUUID AncillaryResourceID { get; set; }

        [Category(CATEGORYNAME)]
        public string MIMEType { get; set; }

        [Category(CATEGORYNAME)]
        public UInt32 EssenceStreamID { get; set; }
        
        public MXFDCTimedTextResourceSubDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "DC Timed Text Resource SubDescriptor")
        {
        }

        /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("AncillaryResourceID", out ul_key))
                AncillaryResourceID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MIMEType", out ul_key))
                MIMEType_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("EssenceStreamID", out ul_key))
                EssenceStreamID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
                    case var _ when localTag.Key == AncillaryResourceID_Key: this.AncillaryResourceID = reader.ReadUUIDKey(); return true;
                    case var _ when localTag.Key == MIMEType_Key: this.MIMEType = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == EssenceStreamID_Key: this.EssenceStreamID = reader.ReadUInt32(); return true;
                }
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
