/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;
using System.Collections.Generic;

namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates an OSC type tag string.
    /// </summary>
    public class OscTypeTagString
    {
        private List<IOscDataType> _arguments = new List<IOscDataType>();

        /// <summary>
        /// Creates an empty type tag string
        /// </summary>
        public OscTypeTagString()
        {
        }

        /// <summary>
        /// Creates a type tag string from the enumerable.
        /// </summary>        
        public OscTypeTagString(IEnumerable<IOscDataType> args)
        {
            _arguments.AddRange((args));
        }

        /// <summary>
        /// Gets or sets the argument list
        /// </summary>
        public List<IOscDataType> Arguments
        {
            get { return _arguments; }
            set
            {
                if (value != null)
                {
                    _arguments = value;
                }
                else
                {
                    _arguments.Clear();
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the type tag character for the given OSC data type.
        /// </summary>
        public char DataTypeToTypeTag(OscDataType type)
        {
            switch (type)
            {
                case OscDataType.Blob:
                    return 'b';

                case OscDataType.Float32:
                    return 'f';

                case OscDataType.Int32:
                    return 'i';

                case OscDataType.String:
                    return 's';

                case OscDataType.True:
                    return 'T';

                case OscDataType.False:
                    return 'F';

                case OscDataType.Null:
                    return 'N';

                case OscDataType.Impulse:
                    return 'I';

                case OscDataType.Timetag:
                    return 't';

                default:
                    throw new ArgumentException("Invalid OSC data type");
            }
        }
    }
}
