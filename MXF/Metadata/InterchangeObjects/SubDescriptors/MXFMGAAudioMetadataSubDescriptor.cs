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
    public class MXFMGAAudioMetadataSubDescriptor : MXFSubDescriptor
    {
        private const string CATEGORYNAME = "MGAAudioMetadataSubDescriptor";
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey MGALinkID_Key;
        private MXFKey MGAAudioMetadataIndex_Key;
        private MXFKey MGAAudioMetadataIdentifier_Key;
        private MXFKey MGAAudioMetadataPayloadULArray_Key;

        [Category(CATEGORYNAME)]
        public MXFUUID MGALinkID { get; set; }

        [Category(CATEGORYNAME)]
        public Byte MGAAudioMetadataIndex { get; set; }

        [Category(CATEGORYNAME)]
        public Byte MGAAudioMetadataIdentifier { get; set; }

        [Category(CATEGORYNAME)]
        public MXFUUID[] MGAAudioMetadataPayloadULArray { get; set; }


        public MXFMGAAudioMetadataSubDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "MGA Audio Metadata SubDescriptor")
        {
        }

        /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("MGALinkID", out ul_key))
                MGALinkID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MGAAudioMetadataIndex", out ul_key))
                MGAAudioMetadataIndex_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MGAAudioMetadataIdentifier", out ul_key))
                MGAAudioMetadataIdentifier_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MGAAudioMetadataPayloadULArray", out ul_key))
                MGAAudioMetadataPayloadULArray_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
                    case var _ when localTag.Key == MGALinkID_Key: this.MGALinkID = reader.ReadUUIDKey(); return true;
                    case var _ when localTag.Key == MGAAudioMetadataIndex_Key: this.MGAAudioMetadataIndex = reader.ReadByte(); return true;
                    case var _ when localTag.Key == MGAAudioMetadataIdentifier_Key: this.MGAAudioMetadataIdentifier = reader.ReadByte(); return true;
                    case var _ when localTag.Key == MGAAudioMetadataPayloadULArray_Key: UInt32 num = reader.ReadUInt32();  reader.Skip(4);  this.MGAAudioMetadataPayloadULArray = reader.ReadArray(reader.ReadUUIDKey, (int)num); return true;
                }
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
