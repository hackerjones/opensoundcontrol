/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System.Collections.Generic;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    ///   Encapsulates an blob.
    /// </summary>
    public class OscBlob : IOscElement
    {
        /// <summary>
        ///   Creates an empty blob.
        /// </summary>
        public OscBlob()
        {
            Buffer = new List<byte>();
        }

        /// <summary>
        ///   Creates an OSC from the enumerable.
        /// </summary>
        public OscBlob(IEnumerable<byte> buffer)
            : this()
        {
            Buffer.AddRange(buffer);
        }

        /// <summary>
        ///   Gets or sets the byte list that contains the blob data.
        /// </summary>
        public List<byte> Buffer { get; set; }

        /// <summary>
        ///   Converts the blob data to a string.
        /// </summary>
        public override string ToString()
        {
            return Encoding.UTF8.GetString(Buffer.ToArray());
        }

        #region Implementation of IOscElement

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.Blob; }
        }

        /// <summary>
        ///   True if the element is also an argument
        /// </summary>
        public bool IsArgument
        {
            get { return true; }
        }

        /// <summary>
        ///   Gets the packet array data for the element.
        /// </summary>
        public byte[] ToOscPacketArray()
        {
            return Osc.PadArray(Buffer.ToArray());
        }

        #endregion
    }
}
