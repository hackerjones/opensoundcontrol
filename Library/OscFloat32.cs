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
    /// Encapsulates an OSC 32-bit floating point number.
    /// </summary>
    public class OscFloat32 : IOscDataType
    {
        public OscFloat32()
        {
        }

        public OscFloat32(float value)
        {
            Value = value;
        }

        public float Value { get; set; }

        #region IOscDataType Members

        public OscDataType DataType
        {
            get { return OscDataType.Float32; }
        }


        public bool HasArgumentData
        {
            get { return true; }
        }

        #endregion

        public override string ToString()
        {
            return Convert.ToString(Value);
        }
    }
}
