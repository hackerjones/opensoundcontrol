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
    /// <summary>
    ///   Encapsulates a type tag string.
    /// </summary>
    public class OscTypeTagString : IOscElement
    {
        private List<OscElementType> _arguments;

        ///<summary>
        ///  Creates an empty type tag string.
        ///</summary>
        public OscTypeTagString()
        {
            Arguments = new List<OscElementType>();
        }

        /// <summary>
        ///   Creates an type tag string from an enumerable.
        /// </summary>
        public OscTypeTagString(IEnumerable<OscElementType> args)
        {
            FilterArguments(args);
        }

        /// <summary>
        ///   Gets and sets the argument list.
        /// </summary>
        public List<OscElementType> Arguments
        {
            get { return _arguments; }
            set { FilterArguments(value); }
        }

        /// <summary>
        ///   Gets the type tag string as an OSC string.
        /// </summary>
        public OscString Value
        {
            get { return new OscString(ToString()); }
        }

        /// <summary>
        ///   Filters out non argument elements before putting them in the list
        /// </summary>
        private void FilterArguments(IEnumerable<OscElementType> args)
        {
            var names = Enum.GetNames(typeof(OscElementType)).Skip(4);
            _arguments = args.Where(i => names.Contains(i.ToString())).ToList();
        }

        /// <summary>
        ///   Returns a <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(',');
            foreach (OscElementType argument in _arguments)
            {
                sb.Append(TypeTagChar(argument));
            }
            return sb.ToString();
        }

        #region Implementation of IOscElement

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.TypeTagString; }
        }

        /// <summary>
        ///   True if the element is also an argument
        /// </summary>
        public bool IsArgument
        {
            get { return false; }
        }

        /// <summary>
        ///   Gets the packet array data for the element.
        /// </summary>
        public byte[] ToPacketArray()
        {
            return Value.ToPacketArray();
        }

        private static char TypeTagChar(OscElementType type)
        {
            switch (type)
            {
                case OscElementType.Int32:
                    return 'i';
                case OscElementType.UInt32:
                    return 'u';
                case OscElementType.Float32:
                    return 'f';
                case OscElementType.String:
                    return 's';
                case OscElementType.Blob:
                    return 'b';
                case OscElementType.True:
                    return 'T';
                case OscElementType.False:
                    return 'F';
                case OscElementType.Null:
                    return 'N';
                case OscElementType.Impulse:
                    return 'I';
                case OscElementType.Timetag:
                    return 't';
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        #endregion
    }
}
