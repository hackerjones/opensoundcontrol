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
    ///   Encapsulates a float.
    /// </summary>
    public class OscFloat32 : IOscElement
    {
        /// <summary>
        ///   Creates a default OSC float.
        /// </summary>
        public OscFloat32()
        {
        }

        /// <summary>
        ///   Creates an OSC float from the given value.
        /// </summary>
        public OscFloat32(float value)
        {
            Value = value;
        }

        /// <summary>
        ///   Gets the float value.
        /// </summary>
        public float Value { get; set; }


        /// <summary>
        ///   Returns a <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
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
            get { return OscElementType.Float32; }
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
