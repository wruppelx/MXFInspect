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
	public class MXF_Template_SubDescriptor : MXFSubDescriptor
	{
		private const string CATEGORYNAME = "_Template_SubDescriptor";
		static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
		private bool ParamsInitiated = false;
		private MXFShortKey ul_key;

		private MXFKey Param1_Key;
		private MXFKey Param2_Key;
		private MXFKey Param3_Key;
		private MXFKey Param4_Key;

        /* Types:
		 * UInt32
		 * byte[]
		 * MXFUUID
		 * string
		 * MXFColorPrimary
		 */
        [Category(CATEGORYNAME)]
		public UInt32 Param1 { get; set; }

		[Category(CATEGORYNAME)]
		public byte[] Param2 { get; set; }

		[Category(CATEGORYNAME)]
		public MXFUUID Param3 { get; set; }

		[Category(CATEGORYNAME)]
		public byte[] Param4 { get; set; }

		public MXF_Template_SubDescriptor(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "NAME Sub-Descriptor")
		{
		}

		/// <summary>
		/// Set ULs for all elements
		/// </summary>
		private void InitParms()
		{
			if (knownSymbols.TryGetValue("Param1", out ul_key))
				Param1_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("Param2", out ul_key))
				Param2_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("Param3", out ul_key))
				Param3_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("Param4", out ul_key))
				Param4_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
                    //UInt32 num = reader.ReadUInt32();  reader.Skip(4);  this.Param2 = reader.ReadArray<byte>(reader.ReadByte, 4)
                    //reader.ReadUTF16String(localTag.Size);
                    case var _ when localTag.Key == Param1_Key: this.Param1 = reader.ReadUInt32(); return true;
					case var _ when localTag.Key == Param2_Key: UInt32 num = reader.ReadUInt32();  reader.Skip(4);  this.Param2 = reader.ReadArray<byte>(reader.ReadByte, 4); return true;
					case var _ when localTag.Key == Param3_Key: this.Param3 = reader.ReadUUIDKey(); return true;
					case var _ when localTag.Key == Param4_Key: this.Param4 = reader.ReadArray<byte>(reader.ReadByte, 20); return true; //SHA-1 has a size of 160 bit
                    //case var _ when localTag.Key == UCSEncoding_Key: this.UCSEncoding = reader.ReadUTF16String(localTag.Size); return true;

                }
            }
			return base.ParseLocalTag(reader, localTag);
		}

	}
}
