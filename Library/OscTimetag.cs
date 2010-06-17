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
    /// Encapsulates an OSC timetag
    /// </summary>
    public class OscTimetag : IOscDataType
    {
        public OscTimetag()
        {
            throw new NotImplementedException();
        }

        #region IOscDataType Members

        public OscDataType DataType
        {
            get { return OscDataType.Timetag; }
        }


        public bool HasArgumentData
        {
            get { return true; }
        }

        #endregion
    }
}
