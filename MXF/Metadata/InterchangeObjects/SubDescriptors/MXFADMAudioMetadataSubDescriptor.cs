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
	public class MXFADMAudioMetadataSubDescriptor : MXFSubDescriptor
	{
		private const string CATEGORYNAME = "ADMAudioMetadataSubDescriptor";
		static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
		private bool ParamsInitiated = false;
		private MXFShortKey ul_key;

		private MXFKey RIFFChunkStreamID_link1_Key;
		private MXFKey ADMProfileLevelULBatch_Key;

		[Category(CATEGORYNAME)]
		public UInt32 RIFFChunkStreamID_link1 { get; set; }

		[Category(CATEGORYNAME)]
        public MXFUUID[] ADMProfileLevelULBatch { get; set; }

		public MXFADMAudioMetadataSubDescriptor(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "ADM Audio Metadata Sub-Descriptor")
		{
		}

		/// <summary>
		/// Set ULs for all elements
		/// </summary>
		private void InitParms()
		{
			if (knownSymbols.TryGetValue("RIFFChunkStreamID_link1", out ul_key))
				RIFFChunkStreamID_link1_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("ADMProfileLevelULBatch", out ul_key))
				ADMProfileLevelULBatch_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("Param3", out ul_key))
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
					case var _ when localTag.Key == RIFFChunkStreamID_link1_Key: this.RIFFChunkStreamID_link1 = reader.ReadUInt32(); return true;
                    case var _ when localTag.Key == ADMProfileLevelULBatch_Key: UInt32 num = reader.ReadUInt32(); reader.Skip(4); this.ADMProfileLevelULBatch = reader.ReadArray(reader.ReadUUIDKey, (int)num); return true;
				}
			}
			return base.ParseLocalTag(reader, localTag);
		}

	}
}
