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
        private OscAddress address;
        private List<IOscDataType> arguments;

        /// <summary>
        /// Creates an empty OSC message.
        /// </summary>
        public OscMessage()
        {
            address = new OscAddress();
            arguments = new List<IOscDataType>();
        }

        public List<IOscDataType> Arguments
        {
            get { return arguments; }
            set
            {
                // don't allow arguments to be set to null
                if (value == null)
                    arguments.Clear();
                else
                    arguments = value;
            }
        }

        public OscAddress Address { get; set; }

        public OscTypeTagString TypeTagString
        {
            get { return new OscTypeTagString(); }
        }

        #region IOscBundleElement Members

        public OscBundleElementType BundleElementType
        {
            get { return OscBundleElementType.Message; }
        }

        #endregion

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
