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
    public class MXFMGASoundfieldGroupLabelSubDescriptor : MXFSoundfieldGroupLabelSubDescriptor
    {
        private const string CATEGORYNAME = "MGASoundfieldGroupLabelSubDescriptor";
        private const int CATEGORYPOS = 5;
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey MGAMetadataSectionLinkID_Key;
        private MXFKey ADMAudioProgrammeID_Key;
        private MXFKey ADMAudioContentID_Key;
        private MXFKey ADMAudioObjectID_Key;

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public MXFUUID MGAMetadataSectionLinkID { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string ADMAudioProgrammeID { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string ADMAudioContentID { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string ADMAudioObjectID { get; set; }


        public MXFMGASoundfieldGroupLabelSubDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "MGA Soundfield Group Label SubDescriptor")
        {
        }

        /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("MGAMetadataSectionLinkID", out ul_key))
                MGAMetadataSectionLinkID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("ADMAudioProgrammeID", out ul_key))
                ADMAudioProgrammeID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("ADMAudioContentID", out ul_key))
                ADMAudioContentID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("ADMAudioObjectID", out ul_key))
                ADMAudioObjectID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
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
                    case var _ when localTag.Key == MGAMetadataSectionLinkID_Key: this.MGAMetadataSectionLinkID = reader.ReadUUIDKey(); return true;
                    case var _ when localTag.Key == ADMAudioProgrammeID_Key: this.ADMAudioProgrammeID = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == ADMAudioContentID_Key: this.ADMAudioContentID = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == ADMAudioObjectID_Key: this.ADMAudioObjectID = reader.ReadUTF16String(localTag.Size); return true;
                }
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
