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
    /// Encapsulates an OSC address.
    /// </summary>
    public class OscAddress
    {
        private OscString _value;

        /// <summary>
        /// Creates an empty OSC address
        /// </summary>
        public OscAddress()
        {
            _value = new OscString();
        }

        /// <summary>
        /// Gets or sets the address value from an OscString
        /// </summary>
        public OscString Value
        {
            get { return _value; }
            set
            {
                if (value == null)
                {
                    _value = new OscString();
                }
            }
        }

        /// <summary>
        /// Converts the OSC address to a string.
        /// </summary>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
