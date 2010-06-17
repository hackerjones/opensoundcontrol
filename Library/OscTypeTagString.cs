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
        private List<IOscDataType> arguments;

        public OscTypeTagString()
        {
            arguments = new List<IOscDataType>();
        }

        public OscTypeTagString(List<IOscDataType> arguments)
        {
            this.arguments = arguments;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

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
