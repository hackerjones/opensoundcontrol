// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
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
            if (obj != null && obj is OscFloat32)
            {
                OscFloat32 other = obj as OscFloat32;
                return Value == other.Value;
            }
            return false;
        }

        ///<summary>
        ///  Compares the value of two OscFloat32 and determines if they are equal
        ///</summary>
        ///<param name = "f1">float one</param>
        ///<param name = "f2">float two</param>
        ///<returns></returns>
        public static bool operator ==(OscFloat32 f1,
                                       OscFloat32 f2)
        {
            if (ReferenceEquals(f1, null))
                throw new ArgumentNullException("f1");

            if (ReferenceEquals(f2, null))
                throw new ArgumentNullException("f2");

            return f1.Equals(f2);
        }

        ///<summary>
        ///  Compares the value of two OscFloat32 and determines if they are not equal
        ///</summary>
        ///<param name = "f1">float one</param>
        ///<param name = "f2">float two</param>
        ///<returns></returns>
        public static bool operator !=(OscFloat32 f1,
                                       OscFloat32 f2)
        {
            if (ReferenceEquals(f1, null))
                throw new ArgumentNullException("f1");

            if (ReferenceEquals(f2, null))
                throw new ArgumentNullException("f2");

            return !f1.Equals(f2);
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
        public byte[] ToOscPacketArray()
        {
            return Value.ToOscPacketArray();
        }

        #endregion
    }
}
