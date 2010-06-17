/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
namespace OpenSoundControl
{
    public enum OscDataType
    {
        /// <summary>
        /// OSC signed 32-bit integer
        /// </summary>
        Int32,
        /// <summary>
        /// OSC unsigned 32-bit integer
        /// </summary>
        UInt32,
        /// <summary>
        /// OSC 32-bit floating point number
        /// </summary>
        Float32,
        /// <summary>
        /// OSC string
        /// </summary>
        String,
        /// <summary>
        /// OSC blob
        /// </summary>
        Blob,
        /// <summary>
        /// OSC true
        /// </summary>
        True,
        /// <summary>
        /// OSC false
        /// </summary>
        False,
        /// <summary>
        /// OSC null
        /// </summary>
        Null,
        /// <summary>
        /// OSC impulse
        /// </summary>
        Impulse,
        /// <summary>
        /// OSC timetag
        /// </summary>
        Timetag
    }

    /// <summary>
    /// Interface for OSC data types
    /// </summary>
    public interface IOscDataType
    {
        /// <value>Gets the OSC data type.</value>
        OscDataType DataType { get; }

        bool HasArgumentData { get; }
    }
}
