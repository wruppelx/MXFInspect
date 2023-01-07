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

using Myriadbits.MXF.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Myriadbits.MXF.Identifiers;

namespace Myriadbits.MXF
{
    [ULGroup("urn:smpte:ul:060e2b34.027f0101.0d010101.01018106")]
    public class MXFMGASoundEssenceDescriptor : MXFGenericSoundEssenceDescriptor
    {
        private const string CATEGORYNAME = "MGASoundEssenceDescriptor";
        private const int CATEGORYPOS = 5;
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;
        private MXFKey soundEssenceBlockAlign_Key; 
        private MXFKey soundEssenceAverageBytesPerSecond_Key; 
        private MXFKey soundEssenceSequenceOffset_Key; 
        
        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public UInt16 MGASoundEssenceBlockAlign { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public UInt32 MGASoundEssenceAverageBytesPerSecond { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public Byte? MGASoundEssenceSequenceOffset { get; set; }

        /// <summary>
        /// Constructor, set the correct descriptor name
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="headerKLV"></param>
        public MXFMGASoundEssenceDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "MGA Sound Essence Descriptor")
        {
        }

         /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("MGASoundEssenceBlockAlign", out ul_key))
                soundEssenceBlockAlign_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MGASoundEssenceAverageBytesPerSecond", out ul_key))
                soundEssenceAverageBytesPerSecond_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MGASoundEssenceSequenceOffset", out ul_key))
                soundEssenceSequenceOffset_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            ParamsInitiated = true;
        }

        /// <summary>
        /// Overridden method to process local tags
        /// </summary>
        /// <param name="localTag"></param>
        protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
        {
            if (!ParamsInitiated) InitParms();
            switch (localTag.Tag)
            {
                case var _ when localTag.Key == soundEssenceBlockAlign_Key: this.MGASoundEssenceBlockAlign = reader.ReadUInt16(); return true;
                case var _ when localTag.Key == soundEssenceAverageBytesPerSecond_Key: this.MGASoundEssenceAverageBytesPerSecond = reader.ReadUInt32(); return true;
                case var _ when localTag.Key == soundEssenceSequenceOffset_Key: this.MGASoundEssenceSequenceOffset = reader.ReadByte(); return true;
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
