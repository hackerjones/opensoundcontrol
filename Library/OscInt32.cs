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
    /// Encapsulates an OSC signed 32-bit integer.
    /// </summary>
    public class OscInt32 : IOscDataType
    {
        /// <summary>
        /// Creates a OSC signed 32-bit integer with the value of zero.
        /// </summary>
        public OscInt32()
        {
            
        }

        /// <summary>
        /// Creates an OSC signed 32-bit integer with the given value.
        /// </summary>
        public OscInt32(int value)
        {
            Value = value;
        }
    
        public OscDataType DataType 
        { 
            get 
            { 
                return OscDataType.Int32;
            }
        }

        public int Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Convert.ToString(Value);
        }
    }
}
