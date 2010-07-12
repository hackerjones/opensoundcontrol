// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
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

        /// <summary>
        ///   Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        ///   A hash code for the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        ///   Determines whether the specified <see cref = "T:System.Object" /> is equal to the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   true if the specified <see cref = "T:System.Object" /> is equal to the current <see cref = "T:System.Object" />; otherwise, false.
        /// </returns>
        /// <param name = "obj">The <see cref = "T:System.Object" /> to compare with the current <see cref = "T:System.Object" />. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is OscString)
            {
                OscString other = obj as OscString;
                return Value == other.Value;
            }
            return false;
        }

        /// <summary>
        ///   Compares the value of two OscString and determines if they are equal
        /// </summary>
        /// <param name = "s1">string one</param>
        /// <param name = "s2">string two</param>
        /// <returns></returns>
        public static bool operator ==(OscString s1,
                                       OscString s2)
        {
            return s1.Equals(s2);
        }

        /// <summary>
        ///   Compares the value of two OscString and determines if they are not equal
        /// </summary>
        /// <param name = "s1">string one</param>
        /// <param name = "s2">string two</param>
        /// <returns>True if the strings are not equal</returns>
        public static bool operator !=(OscString s1,
                                       OscString s2)
        {
            return !s1.Equals(s2);
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
        public byte[] ToOscPacketArray()
        {
            return Osc.PadArray(Encoding.ASCII.GetBytes(Value + '\0'));
        }

        #endregion
    }
}
