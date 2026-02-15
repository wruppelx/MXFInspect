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

using Myriadbits.MXF.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Myriadbits.MXF.Identifiers;

namespace Myriadbits.MXF
{
    [ULGroup("urn:smpte:ul:060e2b34.027f0105.0e090502.00000000")]
    public class MXFISXDDataEssenceDescriptor : MXFGenericDataEssenceDescriptor
    {
        private const string CATEGORYNAME = "MXFISXDDataEssenceDescriptor";
        private const int CATEGORYPOS = 5;
        static readonly Dictionary<string, MXFShortKey> knownSymbols = SymbolDictionary.GetKeys();
        private bool ParamsInitiated = false;
        private MXFShortKey ul_key;
        private MXFKey namespaceUri_Key; 
        
        [SortedCategory(CATEGORYNAME, CATEGORYPOS)]
        public string NamespaceURI { get; set; }

        /// <summary>
        /// Constructor, set the correct descriptor name
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="headerKLV"></param>
        public MXFISXDDataEssenceDescriptor(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV, "ISXD Data Essence Descriptor")
        {
        }

         /// <summary>
        /// Set ULs for all elements
        /// </summary>
        private void InitParms()
        {
            namespaceUri_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x0e, 0x09, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00);
            ParamsInitiated = true;
        }

        /// <summary>
        /// Overridden method to process local tags
        /// </summary>
        /// <param name="localTag"></param>
        protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
        {
            if (!ParamsInitiated) InitParms();
            switch (localTag.Tag)
            {
                case var _ when localTag.Key == namespaceUri_Key: this.NamespaceURI = reader.ReadUTF8String(localTag.Size); return true;
            }
            return base.ParseLocalTag(reader, localTag);
        }

    }
}
