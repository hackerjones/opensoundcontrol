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
    /// Encapsulates an OSC bundle.
    /// </summary>
    public class OscBundle : IOscBundleElement
    {
        private List<IOscBundleElement> elements = new List<IOscBundleElement>();

        /// <summary>
        /// Creates an empty OSC bundle.
        /// </summary>
        public OscBundle()
        {
            
        }

        public OscBundleElementType BundleElementType
        {
            get
            {
                return OscBundleElementType.Bundle;
            }
        }

        public List<IOscBundleElement> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                // don't allow elements to be set to null
                if (value == null)
                    elements.Clear();
                else
                    elements = value;
            }
        }

        public OscTimetag Timetag
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
