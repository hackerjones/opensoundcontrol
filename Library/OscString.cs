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
    /// Encapsulates an OSC string.
    /// </summary>
    public class OscString : IOscDataType
    {
        private string _value;

        /// <summary>
        /// Creates an empty OSC string.
        /// </summary>
        public OscString()
        {
            _value = String.Empty;
        }

        /// <summary>
        /// Creates an OSC string from the given string.
        /// </summary>
        /// <param name="value">String data</param>
        public OscString(string value)
        {
            Value = value;
        }

        /// <value>String value</value>
        public string Value
        {
            get { return _value; }
            set
            {
                if (value == null)
                {
                    _value = String.Empty;
                }
            }
        }

        /// <value>True if empty</value>
        public bool IsEmpty
        {
            get { return _value.Length < 1; }
        }

        #region IOscDataType Members

        /// <summary>
        /// Gets the OSC data type.
        /// </summary>        
        public OscDataType DataType
        {
            get { return OscDataType.String; }
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
            return _value;
        }
    }
}
