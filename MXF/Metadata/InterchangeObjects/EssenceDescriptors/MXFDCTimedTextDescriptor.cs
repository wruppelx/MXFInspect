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
	public class MXFDCTimedTextDescriptor : MXFGenericDataEssenceDescriptor
	{
        private const string CATEGORYNAME = "DCTimedTextDescriptor";
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
        public MXFDCTimedTextDescriptor(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "DC Timed Text Descriptor")
		{
			this.MetaDataName = this.Key.Name;
        }

        /// <summary>
        /// Constructor, set the correct descriptor name
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="headerKLV"></param>
        public MXFDCTimedTextDescriptor(MXFReader reader, MXFKLV headerKLV, string metadataName)
			: base(reader, headerKLV, metadataName)
		{
        }
	}
}
