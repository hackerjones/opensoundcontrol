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
    /// Encapsulates an OSC address.
    /// </summary>
    public class OscAddress
    {
        public OscAddress()
        {
            throw new NotImplementedException();
        }

        public OscString Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
