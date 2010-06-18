/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates an OSC true data type
    /// </summary>
    public class OscTrue : IOscDataType
    {
        #region IOscDataType Members

        /// <summary>
        /// Gets the OSC data type.
        /// </summary>        
        public OscDataType DataType
        {
            get { return OscDataType.True; }
        }

        /// <summary>
        /// Gets if the type has associated argument data.
        /// </summary>
        public bool HasArgumentData
        {
            get { return false; }
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
            return "OscTrue";
        }
    }
}
