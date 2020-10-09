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

using Myriadbits.MXF.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Myriadbits.MXF
{

	/// <summary>
	/// Create the correct MXF (sub) object 
	/// </summary>
	public class MXFKLVFactory
	{
		static List<MXFKey> m_allKeys = new List<MXFKey>();

		static MXFKLVFactory()
		{
			// Main keys
			m_allKeys.Add(new MXFKey(typeof(MXFPartition), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x05, 0x01, 0x01, 0x0d, 0x01, 0x02, 0x01, 0x01, 0x02));
			m_allKeys.Add(new MXFKey(typeof(MXFPartition), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x05, 0x01, 0x01, 0x0d, 0x01, 0x02, 0x01, 0x01, 0x03));
			m_allKeys.Add(new MXFKey(typeof(MXFPartition), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x05, 0x01, 0x01, 0x0d, 0x01, 0x02, 0x01, 0x01, 0x04));
			m_allKeys.Add(new MXFKey(typeof(MXFPrimerPack), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x05, 0x01, 0x01, 0x0d, 0x01, 0x02, 0x01, 0x01, 0x05, 0x01, 0x00));
			m_allKeys.Add(new MXFKey(typeof(MXFSystemItem), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x05, 0x01, 0x01, 0x0d, 0x01, 0x03, 0x01, 0x04));
			m_allKeys.Add(new MXFKey(typeof(MXFSystemItem), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x03, 0x01, 0x14));
			m_allKeys.Add(new MXFKey(typeof(MXFRIP), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x05, 0x01, 0x01, 0x0d, 0x01, 0x02, 0x01, 0x01, 0x11, 0x01, 0x00));


			m_allKeys.Add(new MXFKey(typeof(MXFANCFrameElement), 0x06, 0x0e, 0x2b, 0x34, 0x01, 0x02, 0x01, 0x01, 0x0d, 0x01, 0x03, 0x01, 0x17));
			m_allKeys.Add(new MXFKey(typeof(MXFEssenceElement), 0x06, 0x0e, 0x2b, 0x34, 0x01, 0x02, 0x01, 0x01, 0x0d, 0x01, 0x03, 0x01));
			m_allKeys.Add(new MXFKey(typeof(MXFPackageMetaData), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x43, 0x01, 0x01, 0x0D, 0x01, 0x03, 0x01, 0x04, 0x01));
			m_allKeys.Add(new MXFKey(typeof(MXFPackageMetaData), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x63, 0x01, 0x01, 0x0D, 0x01, 0x03, 0x01, 0x04, 0x01));

			m_allKeys.Add(new MXFKey("AvidEssenceElement", KeyType.Essence, 0x06, 0x0e, 0x2b, 0x34, 0x01, 0x02, 0x01, 0x01, 0x0e, 0x04, 0x03, 0x01));
			m_allKeys.Add(new MXFKey("CryptoSourceContainer", 0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x09, 0x06, 0x01, 0x01, 0x02, 0x02, 0x00, 0x00, 0x00));
			m_allKeys.Add(new MXFKey("EncryptedTriplet", 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x04, 0x01, 0x07, 0x0d, 0x01, 0x03, 0x01, 0x02, 0x7e, 0x01, 0x00));
			m_allKeys.Add(new MXFKey("EncryptedEssenceContainer", 0x06, 0x0e, 0x2b, 0x34, 0x04, 0x01, 0x01, 0x07, 0x0d, 0x01, 0x03, 0x01, 0x02, 0x0b, 0x01, 0x00));
			m_allKeys.Add(new MXFKey("SonyMpeg4ExtraData", 0x06, 0x0e, 0x2b, 0x34, 0x04, 0x01, 0x01, 0x01, 0x0e, 0x06, 0x06, 0x02, 0x02, 0x01, 0x00, 0x00));
			m_allKeys.Add(new MXFKey("Descriptor: Crypto Context", 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x04, 0x01, 0x02, 0x02, 0x00, 0x00));

			// Index
			m_allKeys.Add(new MXFKey(typeof(MXFIndexTableSegment), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x02, 0x01, 0x01, 0x10, 0x01, 0x00));

			// Structural metadata
			m_allKeys.Add(new MXFKey(typeof(MXFPreface), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x2F, 0x00)); // Preface
			m_allKeys.Add(new MXFKey(typeof(MXFIdentification), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x30, 0x00)); // Identification
			m_allKeys.Add(new MXFKey(typeof(MXFContentStorage), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x18, 0x00)); // Content storage
			m_allKeys.Add(new MXFKey(typeof(MXFEssenceContainerData), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x23, 0x00)); // Descriptor: Data container

			m_allKeys.Add(new MXFKey(typeof(MXFMaterialPackage), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x36, 0x00)); // Material package
			m_allKeys.Add(new MXFKey(typeof(MXFSourcePackage), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x37, 0x00)); // Source package
			
			m_allKeys.Add(new MXFKey(typeof(MXFTimelineTrack), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x3B, 0x00)); // Timeline track (all cases)
			m_allKeys.Add(new MXFKey(typeof(MXFEventTrack), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x39, 0x00)); // Event track (DM)
			m_allKeys.Add(new MXFKey(typeof(MXFGenericTrack), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x3A, 0x00)); // Static track

			m_allKeys.Add(new MXFKey(typeof(MXFSequence), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x0F, 0x00)); // Sequence (all cases)
			m_allKeys.Add(new MXFKey(typeof(MXFSourceClip), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x11, 0x00)); // Source clip (picture, sound, data)
			m_allKeys.Add(new MXFKey(typeof(MXFTimecodeComponent), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x14, 0x00)); // Timecode component


			m_allKeys.Add(new MXFKey(typeof(MXFGenericPackage), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x36, 0x00)); // Generic package
			m_allKeys.Add(new MXFKey(typeof(MXFSourcePackage), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x37, 0x00)); // Source package
			m_allKeys.Add(new MXFKey(typeof(MXFGenericTrack), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x3B, 0x00)); // Generic track

			m_allKeys.Add(new MXFKey(typeof(MXFDMSegment), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x41, 0x00)); // DM Segment
			m_allKeys.Add(new MXFKey(typeof(MXFDMSourceClip), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x45, 0x00)); // DM Source clip

			m_allKeys.Add(new MXFKey(typeof(MXFFiller),	0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x09, 0x00)); // Filler
			m_allKeys.Add(new MXFKey(typeof(MXFFiller), 0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x02, 0x03, 0x01, 0x02, 0x10, 0x01, 0x00, 0x00, 0x00));
			m_allKeys.Add(new MXFKey(typeof(MXFFiller), 0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x01, 0x03, 0x01, 0x02, 0x10, 0x01, 0x00, 0x00, 0x00)); // Old filler

			m_allKeys.Add(new MXFKey(typeof(MXFPackageMarkerObject), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x60, 0x00)); // Package marker object
			m_allKeys.Add(new MXFKey(typeof(MXFFileDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x25, 0x00)); // File Descriptor

			// Descriptors
			m_allKeys.Add(new MXFKey(typeof(MXFGenericPictureEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x27, 0x00)); // Generic Picture Essence Descripto
			m_allKeys.Add(new MXFKey(typeof(MXFCDCIPictureEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x28, 0x00)); // CDCI Essence Descriptor
			m_allKeys.Add(new MXFKey(typeof(MXFRGBAPictureEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x29, 0x00)); // RGBA Essence Descriptor
			m_allKeys.Add(new MXFKey(typeof(MXFGenericSoundEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x42, 0x00)); // Generic Sound Essence Descriptor
			m_allKeys.Add(new MXFKey(typeof(MXFGenericDataEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x43, 0x00)); // Generic Data Essence Descriptor
			m_allKeys.Add(new MXFKey(typeof(MXFMultipleDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x44, 0x00)); // MultipleDescriptor

			m_allKeys.Add(new MXFKey(typeof(MXFNetworkLocator), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x32, 0x00)); // Network Locator
			m_allKeys.Add(new MXFKey(typeof(MXFTextLocator), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x33, 0x00)); // Text Locator
			m_allKeys.Add(new MXFKey(typeof(MXFGenericDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x61, 0x00)); // Application Plug-in object
			m_allKeys.Add(new MXFKey(typeof(MXFGenericDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x62, 0x00)); // Application Referenced object

			// EXTRA TODO
			m_allKeys.Add(new MXFKey(typeof(MXFAES3AudioEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x47, 0x00)); // Descriptor: AES3
			m_allKeys.Add(new MXFKey(typeof(MXFWaveAudioEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x48, 0x00)); // Descriptor: Wave
			m_allKeys.Add(new MXFKey(typeof(MXFMPEGPictureEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x51, 0x00)); // Descriptor: MPEG 2 Video
			m_allKeys.Add(new MXFKey(typeof(MXFGenericDataEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x5B, 0x00)); // Descriptor: VBI Data Descriptor, SMPTE 436 - 7.3
			m_allKeys.Add(new MXFKey(typeof(MXFGenericDataEssenceDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x5C, 0x00)); // Descriptor: ANC Data Descriptor, SMPTE 436 - 7.3

            // IMF App#5 urn:smpte:060e2b34.027f0101.0d010101.01017900
            m_allKeys.Add(new MXFKey(typeof(ACESPictureSubDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x79, 0x00)); // ACESPictureSubDescriptor SMPTE ST 2067-50
            m_allKeys.Add(new MXFKey(typeof(TargetFrameSubDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x7a, 0x00)); // TargetFrameSubDescriptor SMPTE ST 2067-50

            // JPEG 2000 SubDescriptor per SMPTE ST 422 urn:smpte:ul:060e2b34.027f0101.0d010101.01015a00
            m_allKeys.Add(new MXFKey(typeof(JPEG2000SubDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x5a, 0x00)); // JPEG2000SubDescriptor SMPTE ST 422

            // MCA Label SubDescriptors per SMPTE ST 377-4
            m_allKeys.Add(new MXFKey(typeof(MCALabelSubDescriptor),                     0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x6a, 0x00));
            m_allKeys.Add(new MXFKey(typeof(AudioChannelLabelSubDescriptor),            0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x6b, 0x00));
            m_allKeys.Add(new MXFKey(typeof(SoundfieldGroupLabelSubDescriptor),         0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x6c, 0x00));
            m_allKeys.Add(new MXFKey(typeof(GroupOfSoundfieldGroupsLabelSubDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x6d, 0x00));

            // DCTimedTextDescriptor per SMPTE ST 429-5
            m_allKeys.Add(new MXFKey(typeof(MXFDCTimedTextDescriptor), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01, 0x01, 0x01, 0x64, 0x00));

            // Generic metadata (when all else fails)
            m_allKeys.Add(new MXFKey(typeof(MXFDescriptiveFramework), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x01, 0x01));
			m_allKeys.Add(new MXFKey(typeof(MXFDescriptiveFramework), 0x06, 0x0e, 0x2b, 0x34, 0x02, 0x53, 0x01, 0x01, 0x0d, 0x01, 0x04, 0x01));

			// XML Document
			m_allKeys.Add(new MXFKey(typeof(XMLDocumentText), 0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x03, 0x01, 0x02, 0x20));
		}


		public MXFKLVFactory()
		{
			// Start by setting all properties of all these classes to readonly
			foreach(MXFKey key in m_allKeys)
			{
				SetTypePropertiesToReadOnly(key.ObjectType);
			}
		}


		/// <summary>
		/// Create a new MXF object based on the KLV key
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="currentPartition"></param>
		/// <returns></returns>
		public MXFKLV CreateObject(MXFReader reader, MXFPartition currentPartition)
		{
			MXFKLV klv = new MXFKLV(reader);
			klv.Partition = currentPartition; // Pass the current partition through to the classes
			foreach (MXFKey knownKey in MXFKLVFactory.m_allKeys)
			{
				if (klv.Key == knownKey)
				{
					if (knownKey.ObjectType != null)
					{						
						return (MXFKLV)Activator.CreateInstance(knownKey.ObjectType, reader, klv);
					}
					klv.Key.Name = knownKey.Name;
					klv.Key.Type = knownKey.Type;
					break;
				}
			}
			return klv;
		}

		/// <summary>
		/// Set all properties to readonly (recursive through to the base classes)
		/// </summary>
		protected void SetTypePropertiesToReadOnly(Type type)
		{
			if (type != null)
			{
				if (type.BaseType != null)
					SetTypePropertiesToReadOnly(type.BaseType);

				foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(type))
				{
					ReadOnlyAttribute attr = prop.Attributes[typeof(ReadOnlyAttribute)] as ReadOnlyAttribute;
					if (attr != null)
					{
						FieldInfo fi = attr.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
						if (fi != null)
							fi.SetValue(attr, true);
					}
				}
			}
		}

		/// <summary>
		/// Update all descriptions with data from the primer pack
		/// </summary>
		public void UpdateAllTypeDescriptions(Dictionary<UInt16, MXFEntryPrimer> allPrimerKeys)
		{
			// Start by setting all properties of all these classes to readonly
			foreach (MXFKey key in m_allKeys)
			{
				UpdateTypeDescriptions(key.ObjectType, allPrimerKeys);
			}
		}


		/// <summary>
		/// Set all properties to readonly (recursive through to the base classes)
		/// </summary>
		public void UpdateTypeDescriptions(Type type, Dictionary<UInt16, MXFEntryPrimer> allPrimerKeys)
		{
			if (type != null && allPrimerKeys != null)
			{
				if (type.BaseType != null)
					UpdateTypeDescriptions(type.BaseType, allPrimerKeys);

				foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(type))
				{
					DescriptionAttribute attr = prop.Attributes[typeof(DescriptionAttribute)] as DescriptionAttribute;
					if (attr != null)
					{
						if (!string.IsNullOrEmpty(attr.Description) && attr.Description.Length == 4)
						{
							string newDescription = "";

							// Get the local tag
							try
							{
								UInt16 localTag = (UInt16)Convert.ToInt32(attr.Description, 16);

								// Find the local tag in the primer pack
								if (allPrimerKeys.ContainsKey(localTag))
								{
									MXFEntryPrimer prime = allPrimerKeys[localTag];
									newDescription = prime.AliasUID.Key.Name;
								}

								FieldInfo fi = attr.GetType().GetField("description", BindingFlags.NonPublic | BindingFlags.Instance);
								if (fi != null)
									fi.SetValue(attr, newDescription);
							}
							catch(Exception)
							{

							}
						}
					}
				}
			}
		}

	}
}
