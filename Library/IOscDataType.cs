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
    public enum OscDataType
    {
        Int32,
        UInt32,
        Float32,
        String,
        Blob,
        True,
        False,
        Null,
        Impulse,
        Timetag
    }

    public interface IOscDataType
    {
        OscDataType DataType { get; }
    }
}
