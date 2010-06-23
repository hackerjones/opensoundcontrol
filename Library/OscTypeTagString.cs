/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
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
        private static readonly Dictionary<char, OscElementType> _charToType;
        private static readonly Dictionary<OscElementType, char> _typeToChar;

        private List<OscElementType> _arguments;

        static OscTypeTagString()
        {
            _charToType = new Dictionary<char, OscElementType>
                              {
                                  { 'i', OscElementType.Int32 },
                                  { 'u', OscElementType.UInt32 },
                                  { 'f', OscElementType.Float32 },
                                  { 's', OscElementType.String },
                                  { 'b', OscElementType.Blob },
                                  { 'T', OscElementType.True },
                                  { 'F', OscElementType.False },
                                  { 'N', OscElementType.Null },
                                  { 'I', OscElementType.Impulse },
                                  { 't', OscElementType.Timetag }
                              };

            _typeToChar = new Dictionary<OscElementType, char>
                              {
                                  { OscElementType.Int32, 'i' },
                                  { OscElementType.UInt32, 'u' },
                                  { OscElementType.Float32, 'f' },
                                  { OscElementType.String, 's' },
                                  { OscElementType.Blob, 'b' },
                                  { OscElementType.True, 'T' },
                                  { OscElementType.False, 'F' },
                                  { OscElementType.Null, 'N' },
                                  { OscElementType.Impulse, 'I' },
                                  { OscElementType.Timetag, 't' }
                              };
        }

        ///<summary>
        ///  Creates an empty type tag string.
        ///</summary>
        public OscTypeTagString()
        {
            Arguments = new List<OscElementType>();
        }

        /// <summary>
        ///   Creates a type tag string from an enumerable.
        /// </summary>
        public OscTypeTagString(IEnumerable<OscElementType> args)
        {
            FilterArguments(args);
        }

        ///<summary>
        ///  Creates a type tag string from a string.
        ///</summary>
        public OscTypeTagString(string str)
            : this()
        {
            foreach (char c in str.Where(i => _charToType.ContainsKey(i)))
            {
                Arguments.Add(_charToType[c]);
            }
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
            _arguments = args.Where(i => _typeToChar.ContainsKey(i)).ToList();
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
                sb.Append(_typeToChar[argument]);
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

        #endregion
    }
}
