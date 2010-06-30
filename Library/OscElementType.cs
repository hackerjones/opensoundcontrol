// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;

namespace OpenSoundControl
{
    /// <summary>
    ///   Element type enumeration.
    /// </summary>
    public enum OscElementType
    {
        /// <summary>
        ///   Message
        /// </summary>
        Message,
        /// <summary>
        ///   Bundle
        /// </summary>
        Bundle,
        /// <summary>
        ///   Address
        /// </summary>
        Address,
        /// <summary>
        ///   Type tag string
        /// </summary>
        TypeTagString,
        /// <summary>
        ///   Signed integer 32-bits
        /// </summary>
        Int32,
        /// <summary>
        ///   Unsigned integer 32-bits
        /// </summary>
        UInt32,
        /// <summary>
        ///   Floating point number 32-bits
        /// </summary>
        Float32,
        /// <summary>
        ///   String
        /// </summary>
        String,
        /// <summary>
        ///   Blob
        /// </summary>
        Blob,
        /// <summary>
        ///   True
        /// </summary>
        True,
        /// <summary>
        ///   False
        /// </summary>
        False,
        /// <summary>
        ///   Null
        /// </summary>
        Null,
        /// <summary>
        ///   Impulse
        /// </summary>
        Impulse,
        /// <summary>
        ///   Timetag
        /// </summary>
        Timetag
    }
}
