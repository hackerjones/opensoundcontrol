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
        /// <summary>
        /// Creates a default OSC float. 
        /// </summary>
        public OscFloat32()
        {
        }

        /// <summary>
        /// Creates an OSC float from the given value.
        /// </summary>        
        public OscFloat32(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the float value.
        /// </summary>
        public float Value { get; set; }

        #region IOscDataType Members

        /// <summary>
        /// Gets the OSC data type.
        /// </summary>        
        public OscDataType DataType
        {
            get { return OscDataType.Float32; }
        }

        /// <summary>
        /// Gets if the type has associated argument data.
        /// </summary>
        public bool HasArgumentData
        {
            get { return true; }
        }

        #endregion

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Convert.ToString(Value);
        }
    }
}
