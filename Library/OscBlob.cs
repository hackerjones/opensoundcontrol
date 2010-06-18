/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates an OSC blob.
    /// </summary>
    public class OscBlob : IOscDataType
    {
        private List<byte> _buffer = new List<byte>();

        /// <summary>
        /// Creates an empty OSC blob.
        /// </summary>
        public OscBlob()
        {
        }

        /// <summary>
        /// Creates an OSC blob from buffer.
        /// </summary>
        public OscBlob(IEnumerable<byte> buffer)
        {
            Buffer.AddRange(buffer);
        }

        /// <summary>
        /// Creates an OSC blob from a byte array segment.
        /// </summary>
        public OscBlob(ArraySegment<byte> bufferSeg)
        {
            for (int i = bufferSeg.Offset; i < (bufferSeg.Offset + bufferSeg.Count); i++)
            {
                Buffer.Add(bufferSeg.Array[i]);
            }
        }

        /// <summary>
        /// Gets or sets the byte list that contains the blob data.
        /// </summary>
        public List<byte> Buffer
        {
            get { return _buffer; }
            set
            {
                // don't allow the list to be set to null
                if (value == null)
                    _buffer.Clear();
                else
                    _buffer = value;
            }
        }


        /// <summary>
        /// Gets the empty state of the blob.
        /// </summary>
        public bool IsEmpty
        {
            get { return (_buffer.Count < 1); }
        }

        #region IOscDataType Members

        /// <summary>
        /// Gets the OSC data type.
        /// </summary>        
        public OscDataType DataType
        {
            get { return OscDataType.Blob; }
        }

        /// <summary>
        /// Gets if the type has associated argument data.
        /// </summary>
        public bool HasArgumentData
        {
            get { return true; }
        }

        #endregion

        /// <summary>
        /// Converts the OSC blob data to a string.
        /// </summary>
        public override string ToString()
        {
            return Encoding.UTF8.GetString(_buffer.ToArray());
        }
    }
}
