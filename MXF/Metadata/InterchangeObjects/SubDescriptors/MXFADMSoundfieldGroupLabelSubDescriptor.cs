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
	public class MXFADMSoundfieldGroupLabelSubDescriptor : MXFSoundfieldGroupLabelSubDescriptor
    {
		private const string CATEGORYNAME = "ADMSoundfieldGroupLabelSubDescriptor";
		static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
		private bool ParamsInitiated = false;
		private MXFShortKey ul_key;

		private MXFKey RIFFChunkStreamID_link2_Key;
		private MXFKey ADMAudioProgrammeID_ST2131_Key;
		private MXFKey ADMAudioContentID_ST2131_Key;
		private MXFKey ADMAudioObjectID_ST2131_Key;

        /* Types:
		 * UInt32
		 * byte[]
		 * MXFUUID
		 */
		[Category(CATEGORYNAME)]
		public UInt32 RIFFChunkStreamID_link2 { get; set; }

		[Category(CATEGORYNAME)]
		public string ADMAudioProgrammeID_ST2131 { get; set; }

		[Category(CATEGORYNAME)]
		public string ADMAudioContentID_ST2131 { get; set; }

		[Category(CATEGORYNAME)]
		public string ADMAudioObjectID_ST2131 { get; set; }

		public MXFADMSoundfieldGroupLabelSubDescriptor(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "ADM Soundfield Group Label Sub-Descriptor")
		{
		}

		/// <summary>
		/// Set ULs for all elements
		/// </summary>
		private void InitParms()
		{
			if (knownSymbols.TryGetValue("RIFFChunkStreamID_link2", out ul_key))
				RIFFChunkStreamID_link2_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("ADMAudioProgrammeID_ST2131", out ul_key))
				ADMAudioProgrammeID_ST2131_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("ADMAudioContentID_ST2131", out ul_key))
				ADMAudioContentID_ST2131_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("ADMAudioObjectID_ST2131", out ul_key))
				ADMAudioObjectID_ST2131_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
		//UInt32 num = reader.ReadUInt32();  reader.Skip(4);  this.ADMAudioProgrammeID_ST2131 = reader.ReadArray<byte>(reader.ReadByte, 4)
					case var _ when localTag.Key == RIFFChunkStreamID_link2_Key: this.RIFFChunkStreamID_link2 = reader.ReadUInt32(); return true;
					case var _ when localTag.Key == ADMAudioProgrammeID_ST2131_Key: this.ADMAudioProgrammeID_ST2131 = reader.ReadUTF16String(localTag.Size); return true;
					case var _ when localTag.Key == ADMAudioContentID_ST2131_Key: this.ADMAudioContentID_ST2131 = reader.ReadUTF16String(localTag.Size); return true;
					case var _ when localTag.Key == ADMAudioObjectID_ST2131_Key: this.ADMAudioObjectID_ST2131 = reader.ReadUTF16String(localTag.Size); return true;
                }
			}
			return base.ParseLocalTag(reader, localTag);
		}

	}
}
