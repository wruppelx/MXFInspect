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
    public class MXFTargetFrameSubDescriptor : MXFSubDescriptor
    {
        private const string CATEGORYNAME = "TargetFrameSubDescriptor";
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey TargetFrameAncillaryResourceID_Key;
        private MXFKey MediaType_Key;
        private MXFKey TargetFrameIndex_Key;
        private MXFKey TargetFrameTransferCharacteristic_Key;
        private MXFKey TargetFrameColorPrimaries_Key;
        private MXFKey TargetFrameComponentMaxRef_Key;
        private MXFKey TargetFrameComponentMinRef_Key;
        private MXFKey TargetFrameEssenceStreamID_Key;
        private MXFKey ACESPictureSubDescriptorInstanceID_Key;
        private MXFKey TargetFrameViewingEnvironment_Key;
        /* Types:
		 * UInt32
		 * byte[]
		 * MXFUUID
		 */
        [Category(CATEGORYNAME)]
        public MXFUUID TargetFrameAncillaryResourceID { get; set; }

        [Category(CATEGORYNAME)]
        public String MediaType { get; set; }

        [Category(CATEGORYNAME)]
        public UInt64 TargetFrameIndex { get; set; }

        [Category(CATEGORYNAME)]
        public MXFKey TargetFrameTransferCharacteristic { get; set; }

        [Category(CATEGORYNAME)]
        public MXFKey TargetFrameColorPrimaries { get; set; }

        [Category(CATEGORYNAME)]
        public UInt32 TargetFrameComponentMaxRef { get; set; }

        [Category(CATEGORYNAME)]
        public UInt32 TargetFrameComponentMinRef { get; set; }

        [Category(CATEGORYNAME)]
        public UInt32 TargetFrameEssenceStreamID { get; set; }

        [Category(CATEGORYNAME)]
        public MXFUUID ACESPictureSubDescriptorInstanceID { get; set; }

        [Category(CATEGORYNAME)]
        public MXFKey TargetFrameViewingEnvironment { get; set; }

        public MXFTargetFrameSubDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "Target Frame Sub-Descriptor")
        {
        }

        /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("TargetFrameAncillaryResourceID", out ul_key))
                TargetFrameAncillaryResourceID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MediaType", out ul_key))
                MediaType_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("TargetFrameIndex", out ul_key))
                TargetFrameIndex_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("TargetFrameTransferCharacteristic", out ul_key))
                TargetFrameTransferCharacteristic_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("TargetFrameColorPrimaries", out ul_key))
                TargetFrameColorPrimaries_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("TargetFrameComponentMaxRef", out ul_key))
                TargetFrameComponentMaxRef_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("TargetFrameComponentMinRef", out ul_key))
                TargetFrameComponentMinRef_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("TargetFrameEssenceStreamID", out ul_key))
                TargetFrameEssenceStreamID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("ACESPictureSubDescriptorInstanceID", out ul_key))
                ACESPictureSubDescriptorInstanceID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("TargetFrameViewingEnvironment", out ul_key))
                TargetFrameViewingEnvironment_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
                    //reader.ReadUInt32();reader.ReadUUIDKey();reader.ReadArray<byte>(reader.ReadByte, 20)
                    //UInt32 num = reader.ReadUInt32();  reader.Skip(4);  this.MediaType = reader.ReadArray<byte>(reader.ReadByte, 4)
                    //reader.ReadUTF16String(localTag.Size);
                    case var _ when localTag.Key == TargetFrameAncillaryResourceID_Key: this.TargetFrameAncillaryResourceID = reader.ReadUUIDKey(); return true;
                    case var _ when localTag.Key == MediaType_Key: this.MediaType = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == TargetFrameIndex_Key: this.TargetFrameIndex = reader.ReadUInt64(); return true;
                    case var _ when localTag.Key == TargetFrameTransferCharacteristic_Key: this.TargetFrameTransferCharacteristic = reader.ReadULKey(); return true; 
                    case var _ when localTag.Key == TargetFrameColorPrimaries_Key: this.TargetFrameColorPrimaries = reader.ReadULKey(); return true; //SHA-1 has a size of 160 bit
                    case var _ when localTag.Key == TargetFrameComponentMaxRef_Key: this.TargetFrameComponentMaxRef = reader.ReadUInt32(); return true; //SHA-1 has a size of 160 bit
                    case var _ when localTag.Key == TargetFrameComponentMinRef_Key: this.TargetFrameComponentMinRef = reader.ReadUInt32(); return true; //SHA-1 has a size of 160 bit
                    case var _ when localTag.Key == TargetFrameEssenceStreamID_Key: this.TargetFrameEssenceStreamID = reader.ReadUInt32(); return true; //SHA-1 has a size of 160 bit
                    case var _ when localTag.Key == ACESPictureSubDescriptorInstanceID_Key: this.ACESPictureSubDescriptorInstanceID = reader.ReadUUIDKey(); return true; //SHA-1 has a size of 160 bit
                    case var _ when localTag.Key == TargetFrameViewingEnvironment_Key: this.TargetFrameViewingEnvironment = reader.ReadULKey(); return true; //SHA-1 has a size of 160 bit
                }
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
