// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;
using System.Net;

namespace OpenSoundControl
{
    /// <summary>
    ///   Encapsulates an time tag
    /// </summary>
    public class OscTimetag : IOscElement
    {
        private static readonly DateTime Epoch = new DateTime(1900, 1, 1);

        /// <summary>
        ///   Creates a time tag from the value in NTP format
        /// </summary>
        public OscTimetag(ulong value)
        {
            Value = value;
        }

        ///<summary>
        ///  Creates a time tag from a DateTime object
        ///</summary>
        ///<param name = "dt">DateTime</param>
        ///<exception cref = "ArgumentOutOfRangeException"></exception>
        public OscTimetag(DateTime dt)
        {
            DateTime = dt;
        }

        /// <summary>
        ///   Time tag in NTP format.
        /// </summary>
        public ulong Value { get; set; }


        ///<summary>
        ///  Gets or sets the time tag as a DateTime object
        ///</summary>
        ///<exception cref = "ArgumentOutOfRangeException"></exception>
        public DateTime DateTime
        {
            get { return Epoch.Add(TimeSpan.FromSeconds(Value & 0xffffffff)); }

            set
            {
                if (value < Epoch)
                    throw new ArgumentOutOfRangeException();

                TimeSpan diff = value.Subtract(Epoch);
                Value = (uint)diff.TotalSeconds;
            }
        }

        ///<summary>
        ///  Returns a time tag that represents the immediately case.
        ///</summary>
        public static OscTimetag Immediately
        {
            get { return new OscTimetag(1); }
        }

        #region Implementation of IOscElement

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.Timetag; }
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
            ulong no = (ulong)IPAddress.HostToNetworkOrder((long)Value);
            byte[] buffer = new byte[8];
            unsafe
            {
                fixed (byte* dstPtr = buffer)
                {
                    byte* srcPtr = (byte*)&no;
                    Osc.MemoryCopy(dstPtr, srcPtr, 8);
                }
            }
            return buffer;
        }

        #endregion
    }
}
