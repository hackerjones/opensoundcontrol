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
    ///   Encapsulates a bundle element.
    /// </summary>
    public class OscBundle : IOscElement
    {
        /// <summary>
        ///   Gets the bundle timetag.
        /// </summary>
        public OscTimetag Timetag { get; set; }

        #region Implementation of IOscElement

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.Bundle; }
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
        public byte[] ToPacketArray()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
