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
	public class MXFADM_CHNASubDescriptor : MXFSubDescriptor
	{
		private const string CATEGORYNAME = "ADM_CHNASubDescriptor";
		static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
		private bool ParamsInitiated = false;
		private MXFShortKey ul_key;

		private MXFKey NumLocalChannels_Key;
		private MXFKey NumADMAudioTrackUIDs_Key;
		private MXFKey ADMChannelMappingsArray_Key;

		[Category(CATEGORYNAME)]
		public UInt16 NumLocalChannels { get; set; }

		[Category(CATEGORYNAME)]
		public UInt16 NumADMAudioTrackUIDs { get; set; }

		public MXFADM_CHNASubDescriptor(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "ADM CHNA Sub-Descriptor")
		{
		}

		/// <summary>
		/// Set ULs for all elements
		/// </summary>
		private void InitParms()
		{
			if (knownSymbols.TryGetValue("NumLocalChannels", out ul_key))
				NumLocalChannels_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("NumADMAudioTrackUIDs", out ul_key))
				NumADMAudioTrackUIDs_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
			if (knownSymbols.TryGetValue("ADMChannelMappingsArray", out ul_key))
                ADMChannelMappingsArray_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
					case var _ when localTag.Key == NumLocalChannels_Key: this.NumLocalChannels = reader.ReadUInt16(); return true;
					case var _ when localTag.Key == NumADMAudioTrackUIDs_Key: this.NumADMAudioTrackUIDs = reader.ReadUInt16(); return true;
					case var _ when localTag.Key == ADMChannelMappingsArray_Key: this.AddChild(reader.ReadReferenceSet<MXFADMChannelMapping>("ADMChannelMappings", "ADMChannelMapping")); return true;
                }
			}
			return base.ParseLocalTag(reader, localTag);
		}

	}
}
