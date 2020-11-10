﻿#region license
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

using System.ComponentModel;

namespace Myriadbits.MXF
{
    public class MXFDMS1Framework : MXFDescriptiveFramework
    {
        public readonly MXFKey frameworkTitle_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x01, 0x05, 0x0f, 0x01, 0x00, 0x00, 0x00, 0x00);
        public readonly MXFKey extTextLanguageCode_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x07, 0x03, 0x01, 0x01, 0x02, 0x02, 0x13, 0x00, 0x00);
        public readonly MXFKey primExtSpokenLanguageCode_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x07, 0x03, 0x01, 0x01, 0x02, 0x03, 0x11, 0x00, 0x00);
        public readonly MXFKey secExtSpokenLanguageCode_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x07, 0x03, 0x01, 0x01, 0x02, 0x03, 0x12, 0x00, 0x00);
        public readonly MXFKey orgExtSpokenLanguageCode_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x07, 0x03, 0x01, 0x01, 0x02, 0x03, 0x13, 0x00, 0x00);
        public readonly MXFKey thesaurusName_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x03, 0x02, 0x01, 0x02, 0x15, 0x01, 0x00, 0x00);
        public readonly MXFKey contactsListObject_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x02, 0x40, 0x22, 0x00);
        public readonly MXFKey locations_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x03, 0x40, 0x16, 0x00);
        public readonly MXFKey titlesObjects_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x05, 0x40, 0x04, 0x00);
        public readonly MXFKey annotationObjects_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x05, 0x40, 0x0d, 0x00);
        public readonly MXFKey participantObjects_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x05, 0x40, 0x13, 0x00);
        public readonly MXFKey metadataServerLocators_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x06, 0x0c, 0x00, 0x00);

        [CategoryAttribute("DMS1Framework"), Description("")]
        public string FrameworkTitle { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public string FrameworkExtendedTextLanguageCode { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public string PrimaryExtendedSpokenLanguageCode { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public string SecondaryExtendedSpokenLanguageCode { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public string OriginalExtendedSpokenLanguageCode { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public string FrameworkThesaurusName { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        //public MXFRefKey ContactsListObject { get; set; }
        //[CategoryAttribute("DMS1Framework"), Description("")]
        //public MXFRefKey Locations { get; set; }
        //[CategoryAttribute("DMS1Framework"), Description("")]
        public MXFRefKey TitlesObjects { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public MXFRefKey AnnotationObjects { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public MXFRefKey ParticipantObjects { get; set; }
        [CategoryAttribute("DMS1Framework"), Description("")]
        public MXFRefKey MetadataServerLocators { get; set; }

        public MXFDMS1Framework(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV)
        {
            this.MetaDataName = "DMS1Framework";
        }

        /// <summary>
        /// Overridden method to process local tags
        /// </summary>
        /// <param name="localTag"></param>
        protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
        {
            if (localTag.Key != null)
            {
                switch (localTag.Key)
                {
                    case var a when localTag.Key == frameworkTitle_Key: this.FrameworkTitle = reader.ReadUTF16String(localTag.Size); return true;
                    case var a when localTag.Key == extTextLanguageCode_Key: this.FrameworkExtendedTextLanguageCode = reader.ReadUTF8String(localTag.Size); return true;
                    case var a when localTag.Key == primExtSpokenLanguageCode_Key: this.PrimaryExtendedSpokenLanguageCode = reader.ReadUTF8String(localTag.Size); return true;
                    case var a when localTag.Key == secExtSpokenLanguageCode_Key: this.SecondaryExtendedSpokenLanguageCode = reader.ReadUTF8String(localTag.Size); return true;
                    case var a when localTag.Key == orgExtSpokenLanguageCode_Key: this.OriginalExtendedSpokenLanguageCode = reader.ReadUTF8String(localTag.Size); return true;
                    case var a when localTag.Key == thesaurusName_Key: this.FrameworkThesaurusName = reader.ReadUTF8String(localTag.Size); return true;
                    case var a when localTag.Key == contactsListObject_Key: ReadStrongReference(reader, "ContactsList Object"); return true;
                    case var a when localTag.Key == locations_Key: ReadKeyList(reader, "Location Objects", "Location Object"); return true;
                    case var a when localTag.Key == titlesObjects_Key: this.TitlesObjects = reader.ReadRefKey(); return true;
                    case var a when localTag.Key == annotationObjects_Key: this.AnnotationObjects = reader.ReadRefKey(); return true;
                    case var a when localTag.Key == participantObjects_Key: this.ParticipantObjects = reader.ReadRefKey(); return true;
                    case var a when localTag.Key == metadataServerLocators_Key: this.MetadataServerLocators = reader.ReadRefKey(); return true;
                }
            }

            return base.ParseLocalTag(reader, localTag);
        }
    }
}
