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
	public class MXFRIFFChunkDefinitionSubDescriptor : MXFSubDescriptor
	{
		private const string CATEGORYNAME = "RIFFChunkDefinitionSubDescriptor";
		static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
		private bool ParamsInitiated = false;
		private MXFShortKey ul_key;

		private MXFKey RIFFChunkStreamID_Key;
		private MXFKey RIFFChunkID_Key;
		private MXFKey RIFFChunkUUID_Key;
		private MXFKey RIFFChunkHashSHA1_Key;

		[Category(CATEGORYNAME)]
		public UInt32 RIFFChunkStreamID { get; set; }

		[Category(CATEGORYNAME)]
		public byte[] RIFFChunkID { get; set; }

		[Category(CATEGORYNAME)]
		public MXFUUID RIFFChunkUUID { get; set; }

		[Category(CATEGORYNAME)]
		public byte[] RIFFChunkHashSHA1 { get; set; }

		public MXFRIFFChunkDefinitionSubDescriptor(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "RIFF Chunk Definition Sub-Descriptor")
		{
		}

		/// <summary>
		/// Set ULs for all elements
		/// </summary>
		private void InitParms()
		{
			if (knownSymbols.TryGetValue("RIFFChunkStreamID", out ul_key))
				RIFFChunkStreamID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("RIFFChunkID", out ul_key))
				RIFFChunkID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("RIFFChunkUUID", out ul_key))
				RIFFChunkUUID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("RIFFChunkHashSHA1", out ul_key))
				RIFFChunkHashSHA1_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
					case var _ when localTag.Key == RIFFChunkStreamID_Key: this.RIFFChunkStreamID = reader.ReadUInt32(); return true;
					case var _ when localTag.Key == RIFFChunkID_Key: UInt32 num = reader.ReadUInt32();  reader.Skip(4);  this.RIFFChunkID = reader.ReadArray<byte>(reader.ReadByte, 4); return true;
					case var _ when localTag.Key == RIFFChunkUUID_Key: this.RIFFChunkUUID = reader.ReadUUIDKey(); return true;
					case var _ when localTag.Key == RIFFChunkHashSHA1_Key: this.RIFFChunkHashSHA1 = reader.ReadArray<byte>(reader.ReadByte, 20); return true; //SHA-1 has a size of 160 bit
				}
			}
			return base.ParseLocalTag(reader, localTag);
		}

	}
}
