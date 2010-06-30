// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenSoundControl
{
    /// <summary>
    ///   Encapsulates an address.
    /// </summary>
    public class OscAddress : IOscElement
    {
        private OscString _value;

        /// <summary>
        ///   Creates an empty address
        /// </summary>
        public OscAddress()
        {
            Value = new OscString();
        }

        /// <summary>
        ///   Creates an address from the input string.
        /// </summary>
        /// <param name = "value"></param>
        public OscAddress(string value)
        {
            Value = new OscString(value);
        }

        /// <summary>
        ///   Gets or sets the address value as an OSC string.
        /// </summary>
        public OscString Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value != null)
                {
                    // take characters before the null
                    string addr = new string(_value.ToString().TakeWhile(i => i != '\0').ToArray());
                    if (!Validate(addr))
                    {
                        throw new ArgumentException("Address contains invalid characters");
                    }
                }
            }
        }

        private static bool Validate(string addr)
        {
            // must start with /
            if (!addr.StartsWith("/"))
            {
                return false;
            }

            // must not contain any of these characters
            MatchCollection badChars = Regex.Matches(addr, @"[\]\[\}\{\*#,\?\s]");
            return badChars.Count <= 0;
        }

        /// <summary>
        ///   Returns a <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Value.ToString();
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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            OscAddress other = (OscAddress)obj;
            return (this == other);
        }

        /// <summary>
        ///   Compares the value of two OscAddress and determines if they are equal
        /// </summary>
        /// <param name = "a1">address one</param>
        /// <param name = "a2">address two</param>
        /// <returns></returns>
        public static bool operator ==(OscAddress a1,
                                       OscAddress a2)
        {
            return (a1.Value == a2.Value);
        }

        /// <summary>
        ///   Compares the value of two OscAddress and determines if they are not equal
        /// </summary>
        /// <param name = "a1">address one</param>
        /// <param name = "a2">address two</param>
        /// <returns></returns>
        public static bool operator !=(OscAddress a1,
                                       OscAddress a2)
        {
            return !(a1 == a2);
        }

        #region Implementation of IOscElement

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.Address; }
        }

        /// <summary>
        ///   True if the element is also an argument
        /// </summary>
        public bool IsArgument
        {
            get { return false; }
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
