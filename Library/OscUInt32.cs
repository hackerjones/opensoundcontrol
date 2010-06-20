/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;

namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates an unsigned integer.
    /// </summary>
    public class OscUInt32 : IOscElement
    {
        /// <summary>
        /// Creates a OSC unsigned 32-bit integer with the value of zero.
        /// </summary>
        public OscUInt32()
        {
        }

        /// <summary>
        /// Creates an OSC unsigned 32-bit integer with the given value.
        /// </summary>
        public OscUInt32(uint value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the unsigned integer value.
        /// </summary>
        public uint Value { get; set; }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Convert.ToString(Value);
        }

        #region Implementation of IOscElement

        /// <summary>
        /// Gets the element type.
        /// </summary>        
        public OscElementType ElementType
        {
            get { return OscElementType.UInt32; }
        }

        /// <summary>
        ///  True if the element is also an argument
        /// </summary>
        public bool IsArgument
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the packet array data for the element.
        /// </summary>        
        public byte[] ToPacketArray()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
