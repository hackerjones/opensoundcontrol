// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
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
            if (obj != null && obj is OscInt32)
            {
                OscInt32 other = obj as OscInt32;
                return Value == other.Value;
            }
            return false;
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
            return Value;
        }


        ///<summary>
        ///  Compares the value of two OscInt32 and determines if they are equal
        ///</summary>
        ///<param name = "i1">integer one</param>
        ///<param name = "i2">integer two</param>
        ///<returns></returns>
        ///<exception cref = "ArgumentNullException"></exception>
        public static bool operator ==(OscInt32 i1,
                                       OscInt32 i2)
        {
            if (ReferenceEquals(i1, null))
                throw new ArgumentNullException("i1");

            if (ReferenceEquals(i2, null))
                throw new ArgumentNullException("i2");

            return i1.Equals(i2);
        }

        ///<summary>
        ///  Compares the value of two OscInt32 and determines if they are not equal
        ///</summary>
        ///<param name = "i1">integer one</param>
        ///<param name = "i2">integer two</param>
        ///<returns></returns>
        ///<exception cref = "ArgumentNullException"></exception>
        public static bool operator !=(OscInt32 i1,
                                       OscInt32 i2)
        {
            if (ReferenceEquals(i1, null))
                throw new ArgumentNullException("i1");

            if (ReferenceEquals(i2, null))
                throw new ArgumentNullException("i2");

            return !i1.Equals(i2);
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
        public byte[] ToOscPacketArray()
        {
            return Value.ToOscPacketArray();
        }

        #endregion
    }
}
