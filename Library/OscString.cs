/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    ///   Encapsulates an string.
    /// </summary>
    public class OscString : IOscElement
    {
        /// <summary>
        ///   Creates an empty string.
        /// </summary>
        public OscString()
        {
            Value = String.Empty;
        }

        /// <summary>
        ///   Creates an OSC string from the given string.
        /// </summary>
        /// <param name = "value">String data</param>
        public OscString(string value)
        {
            Value = value;
        }

        /// <value>String value</value>
        public string Value { get; set; }

        /// <summary>
        ///   Returns a <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Value;
        }

        #region Implementation of IOscElement

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.String; }
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
            return OscPacket.PadArray(Encoding.ASCII.GetBytes(Value));
        }

        #endregion
    }
}
