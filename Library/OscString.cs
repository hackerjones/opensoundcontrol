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
    /// Encapsulates an OSC string.
    /// </summary>
    public class OscString : IOscDataType
    {
        public OscString()
        {
            
        }

        public OscString(string value)
        {
            Value = value;
        }
    
        public OscDataType DataType 
        { 
            get 
            { 
                return OscDataType.String; 
            } 
        }

        public string Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
