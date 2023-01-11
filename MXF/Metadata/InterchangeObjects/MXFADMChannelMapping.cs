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
using System.Collections.Generic;
using System.ComponentModel;
using Myriadbits.MXF.Identifiers;

namespace Myriadbits.MXF
{
	public class MXFADMChannelMapping : MXFInterchangeObject
	{
		private const string CATEGORYNAME = "ADMChannelMapping";
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey LocalChannelID_Key;
        private MXFKey ADMAudioTrackUID_Key;
        private MXFKey ADMAudioTrackChannelFormatID_Key;
        private MXFKey ADMAudioPackFormatID_Key;


        [Category(CATEGORYNAME)]
		public UInt32 LocalChannelID { get; set; }

		[Category(CATEGORYNAME)]
		public string ADMAudioTrackUID { get; set; }

		[Category(CATEGORYNAME)]
		public string ADMAudioTrackChannelFormatID { get; set; }

		[Category(CATEGORYNAME)]
		public string ADMAudioPackFormatID { get; set; }

		public MXFADMChannelMapping(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "ADM Channel Mapping")
		{
		}

		/// <summary>
		/// Set ULs for all elements
		/// </summary>
		private void InitParms()
		{
			if (knownSymbols.TryGetValue("LocalChannelID", out ul_key))
                LocalChannelID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("ADMAudioTrackUID", out ul_key))
                ADMAudioTrackUID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("ADMAudioTrackChannelFormatID", out ul_key))
                ADMAudioTrackChannelFormatID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("ADMAudioPackFormatID", out ul_key))
                ADMAudioPackFormatID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
        }

        /// <summary>
        /// Overridden method to process local tags
        /// </summary>
        /// <param name="localTag"></param>
        protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
		{
            if (!ParamsInitiated) InitParms();
            switch (localTag.Key)
			{
                case var _ when localTag.Key == LocalChannelID_Key: this.LocalChannelID = reader.ReadUInt32(); return true;
                case var _ when localTag.Key == ADMAudioTrackUID_Key: this.ADMAudioTrackUID = reader.ReadUTF16String(localTag.Size); return true;
                case var _ when localTag.Key == ADMAudioTrackChannelFormatID_Key: this.ADMAudioTrackChannelFormatID = reader.ReadUTF16String(localTag.Size); return true;
                case var _ when localTag.Key == ADMAudioPackFormatID_Key: this.ADMAudioPackFormatID = reader.ReadUTF16String(localTag.Size); return true;
            }
            return base.ParseLocalTag(reader, localTag);
		}

	}
}
