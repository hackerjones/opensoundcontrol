/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates an OSC unsigned 32-bit integer.
    /// </summary>
    public class OscUInt32 : IOscDataType
    {
        /// <summary>
        /// Creates a OSC unsigned 32-bit integer with the value of zero.
        /// </summary>
        public OscUInt32()
        {

        }

        /// <summary>
        /// Creates an OSC unsigned 32-bit integer with the given value.
        /// </summary>
        public OscUInt32(uint value)
        {
            Value = value;
        }

        public uint Value
        {
            get;
            set;
        }

        public OscDataType DataType
        {
            get
            {
                return OscDataType.UInt32;
            }
        }

        public override string ToString()
        {
            return Convert.ToString(Value);
        }
    }
}
