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
    public class MXFMCALabelSubDescriptor : MXFSubDescriptor
    {
        private const string CATEGORYNAME = "MCA Label SubDescriptor";
        private const int CATEGORYPOS = 3;
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;

        private MXFKey MCALabelDictionaryID_Key;
        private MXFKey MCALinkID_Key;
        private MXFKey MCATagSymbol_Key;
        private MXFKey MCATagName_Key;
        private MXFKey RFC5646SpokenLanguage_Key;
        private MXFKey MCAChannelID_Key;
        private MXFKey MCATitle_Key;
        private MXFKey MCATitleVersion_Key;
        private MXFKey MCATitleSubVersion_Key;
        private MXFKey MCAEpisode_Key;
        private MXFKey MCAPartitionKind_Key;
        private MXFKey MCAPartitionNumber_Key;
        private MXFKey MCAAudioContentKind_Key;
        private MXFKey MCAAudioElementKind_Key;
        private MXFKey MCAContent_Key;
        private MXFKey MCAUseClass_Key;
        private MXFKey MCAContentSubtype_Key;
        private MXFKey MCAContentDifferentiator_Key;
        private MXFKey MCASpokenLanguageAttribute_Key;
        private MXFKey RFC5646AdditionalSpokenLanguages_Key;
        private MXFKey MCAAdditionalLanguageAttributes_Key;
 
        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public MXFKey MCALabelDictionaryID { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public MXFUUID MCALinkID { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string MCATagSymbol { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCATagName { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? RFC5646SpokenLanguage { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public UInt32? MCAChannelID { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCATitle { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCATitleVersion { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCATitleSubVersion { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAEpisode { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAPartitionKind { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAPartitionNumber { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAAudioContentKind { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAAudioElementKind { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAContent { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAUseClass { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAContentSubtype { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAContentDifferentiator { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCASpokenLanguageAttribute { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? RFC5646AdditionalSpokenLanguages { get; set; }

        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string? MCAAdditionalLanguageAttributes { get; set; }

        public MXFMCALabelSubDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "MCA Label SubDescriptor")
        {
        }

        public MXFMCALabelSubDescriptor(MXFReader reader, MXFKLV headerKLV, string name) : base(reader, headerKLV, name)
        {
        }


        /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            if (knownSymbols.TryGetValue("MCALabelDictionaryID", out ul_key))
                MCALabelDictionaryID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCALinkID", out ul_key))
                MCALinkID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCATagSymbol", out ul_key))
                MCATagSymbol_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCATagName", out ul_key))
                MCATagName_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAChannelID", out ul_key))
                MCAChannelID_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("RFC5646SpokenLanguage", out ul_key))
                RFC5646SpokenLanguage_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCATitle", out ul_key))
                MCATitle_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCATitleVersion", out ul_key))
                MCATitleVersion_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCATitleSubVersion", out ul_key))
                MCATitleSubVersion_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAEpisode", out ul_key))
                MCAEpisode_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAPartitionKind", out ul_key))
                MCAPartitionKind_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAPartitionNumber", out ul_key))
                MCAPartitionNumber_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAAudioContentKind", out ul_key))
                MCAAudioContentKind_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAAudioElementKind", out ul_key))
                MCAAudioElementKind_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAContent", out ul_key))
                MCAContent_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAUseClass", out ul_key))
                MCAUseClass_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAContentSubtype", out ul_key))
                MCAContentSubtype_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAContentDifferentiator", out ul_key))
                MCAContentDifferentiator_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCASpokenLanguageAttribute", out ul_key))
                MCASpokenLanguageAttribute_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("RFC5646AdditionalSpokenLanguages", out ul_key))
                RFC5646AdditionalSpokenLanguages_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));
            if (knownSymbols.TryGetValue("MCAAdditionalLanguageAttributes", out ul_key))
                MCAAdditionalLanguageAttributes_Key = new MXFKey(MXFKey.MXFShortKeytoByteArray(ul_key));

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
                    case var _ when localTag.Key == MCALabelDictionaryID_Key: this.MCALabelDictionaryID = reader.ReadULKey(); return true;
                    case var _ when localTag.Key == MCALinkID_Key: this.MCALinkID = reader.ReadUUIDKey(); return true;
                    case var _ when localTag.Key == MCATagSymbol_Key: this.MCATagSymbol = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCATagName_Key: this.MCATagName = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAChannelID_Key: this.MCAChannelID = reader.ReadUInt32(); return true;
                    case var _ when localTag.Key == RFC5646SpokenLanguage_Key: this.RFC5646SpokenLanguage = reader.ReadUTF8String(localTag.Size); return true;
                    case var _ when localTag.Key == MCATitle_Key: this.MCATitle = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCATitleVersion_Key: this.MCATitleVersion = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCATitleSubVersion_Key: this.MCATitleSubVersion = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAEpisode_Key: this.MCAEpisode = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAPartitionKind_Key: this.MCAPartitionKind = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAPartitionNumber_Key: this.MCAPartitionNumber = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAAudioContentKind_Key: this.MCAAudioContentKind = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAAudioElementKind_Key: this.MCAAudioElementKind = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAContent_Key: this.MCAContent = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAUseClass_Key: this.MCAUseClass = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAContentSubtype_Key: this.MCAContentSubtype = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAContentDifferentiator_Key: this.MCAContentDifferentiator = reader.ReadUTF16String(localTag.Size); return true;
                    case var _ when localTag.Key == MCASpokenLanguageAttribute_Key: this.MCASpokenLanguageAttribute = reader.ReadUTF8String(localTag.Size); return true;
                    case var _ when localTag.Key == RFC5646AdditionalSpokenLanguages_Key: this.RFC5646AdditionalSpokenLanguages = reader.ReadUTF8String(localTag.Size); return true;
                    case var _ when localTag.Key == MCAAdditionalLanguageAttributes_Key: this.MCAAdditionalLanguageAttributes = reader.ReadUTF8String(localTag.Size); return true;
        }
    }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}

