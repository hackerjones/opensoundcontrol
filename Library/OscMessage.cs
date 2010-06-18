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
    /// Encapsulates an OSC message.
    /// </summary>
    public class OscMessage : IOscBundleElement
    {
        private List<IOscDataType> _arguments;

        /// <summary>
        /// Creates an empty OSC message.
        /// </summary>
        public OscMessage()
        {
            Address = new OscAddress();
            _arguments = new List<IOscDataType>();
        }

        /// <summary>
        /// Gets or sets the message argument list
        /// </summary>
        public List<IOscDataType> Arguments
        {
            get { return _arguments; }
            set
            {
                // don't allow arguments to be set to null
                if (value == null)
                    _arguments.Clear();
                else
                    _arguments = value;
            }
        }

        /// <summary>
        /// Gets or sets the message address.
        /// </summary>
        public OscAddress Address { get; set; }

        /// <summary>
        /// Gets the message type tag string
        /// </summary>
        public OscTypeTagString TypeTagString
        {
            get { return new OscTypeTagString(); }
        }

        #region IOscBundleElement Members

        /// <summary>
        /// Gets the type of bundle element.
        /// </summary>
        public OscBundleElementType BundleElementType
        {
            get { return OscBundleElementType.Message; }
        }

        #endregion

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
    }
}
