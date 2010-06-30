// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    ///   Encapsulates a bundle element.
    /// </summary>
    public class OscBundle : IOscElement
    {
        private List<IOscElement> _elements;

        /// <summary>
        ///   Creates an empty bundle
        /// </summary>
        public OscBundle()
        {
            _elements = new List<IOscElement>();
        }


        /// <summary>
        ///   Gets or sets the list of elements contained in the bundle.
        /// </summary>
        public List<IOscElement> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                // filter out elements that are not a bundle or message
                _elements =
                    _elements.Where(
                        i => i.ElementType == OscElementType.Bundle || i.ElementType == OscElementType.Message).ToList();
            }
        }

        /// <summary>
        ///   Gets or sets the bundle timetag.
        /// </summary>
        public OscTimetag Timetag { get; set; }

        #region Implementation of IOscElement

        /// <summary>
        ///   True if the element is also an argument
        /// </summary>
        public bool IsArgument
        {
            get { return false; }
        }

        /// <summary>
        ///   Gets the element type.
        /// </summary>
        public OscElementType ElementType
        {
            get { return OscElementType.Bundle; }
        }

        /// <summary>
        ///   Gets the packet array data for the element.
        /// </summary>
        public byte[] ToOscPacketArray()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        ///   Returns a <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.String" /> that represents the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            _elements.ForEach(i => sb.AppendLine(i.ToString()));
            return sb.ToString();
        }
    }
}
