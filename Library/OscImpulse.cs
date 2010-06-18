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
    /// Encapsulates an OSC impulse data type
    /// </summary>
    public class OscImpulse : IOscDataType
    {
        #region IOscDataType Members

        /// <summary>
        /// Gets the OSC data type.
        /// </summary>        
        public OscDataType DataType
        {
            get { return OscDataType.Impulse; }
        }

        /// <summary>
        /// Gets if the type has associated argument data.
        /// </summary>
        public bool HasArgumentData
        {
            get { return false; }
        }

        #endregion
    }
}
