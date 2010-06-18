/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System.Collections.Generic;

namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates an OSC bundle.
    /// </summary>
    public class OscBundle : IOscBundleElement
    {
        private List<IOscBundleElement> _elements = new List<IOscBundleElement>();

        /// <summary>
        /// Gets or sets the list containing the bundle elements
        /// </summary>
        public List<IOscBundleElement> Elements
        {
            get { return _elements; }
            set
            {
                // don't allow elements to be set to null
                if (value == null)
                    _elements.Clear();
                else
                    _elements = value;
            }
        }

        /// <summary>
        /// Gets the bundle timetag. 
        /// </summary>
        public OscTimetag Timetag { get; set; }

        #region IOscBundleElement Members

        /// <summary>
        /// Gets the type of bundle element.
        /// </summary>
        public OscBundleElementType BundleElementType
        {
            get { return OscBundleElementType.Bundle; }
        }

        #endregion
    }
}
