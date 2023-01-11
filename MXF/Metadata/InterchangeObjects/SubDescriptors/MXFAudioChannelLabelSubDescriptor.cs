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
using Myriadbits.MXF.Utils;

namespace Myriadbits.MXF
{
    public class MXFAudioChannelLabelSubDescriptor : MXFMCALabelSubDescriptor
    {
        private const string CATEGORYNAME = "Audio Channel Label SubDescriptor";
        private const int CATEGORYPOS = 4;
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey SoundfieldGroupLinkID_Key;

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public MXFUUID SoundfieldGroupLinkID { get; set; }

        public MXFAudioChannelLabelSubDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "Audio Channel Label SubDescriptor")
        {
        }

        public MXFAudioChannelLabelSubDescriptor(MXFReader reader, MXFKLV headerKLV, string name) : base(reader, headerKLV, name)
        {
        }


        /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("SoundfieldGroupLinkID", out ul_key))
                SoundfieldGroupLinkID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));

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
                    case var _ when localTag.Key == SoundfieldGroupLinkID_Key: this.SoundfieldGroupLinkID = reader.ReadUUIDKey(); return true;
                }
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
