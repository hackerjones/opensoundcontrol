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
    ///   Encapsulates an signed integer
    /// </summary>
    public class OscInt32 : IOscElement
    {
        /// <summary>
        ///   Creates a OSC signed 32-bit integer with the value of zero.
        /// </summary>
        public OscInt32()
        {
        }

        /// <summary>
        ///   Creates an OSC signed 32-bit integer with the given value.
        /// </summary>
        public OscInt32(int value)
        {
            Value = value;
        }

        /// <summary>
        ///   Gets the signed integer value.
        /// </summary>
        public int Value { get; set; }


        /// <summary>
        ///   Converts the OSC signed 32-bit integer to a string.
        /// </summary>
        public override string ToString()
        {
            return Convert.ToString(Value);
        }

        #region Implementation of IOscElement

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.Int32; }
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
        public byte[] ToPacketArray()
        {
            return OscPacket.ToPacketArray(Value);
        }

        #endregion
    }
}
