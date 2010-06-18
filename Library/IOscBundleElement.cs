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
    /// Bundle element type enumeration.
    /// </summary>
    public enum OscBundleElementType
    {
        /// <summary>
        /// Message element
        /// </summary>
        Message,
        /// <summary>
        /// Bundle element
        /// </summary>
        Bundle
    }

    /// <summary>
    /// Interface for OSC bundle elements
    /// </summary>
    public interface IOscBundleElement
    {
        /// <summary>
        /// Gets the type of bundle element.
        /// </summary>
        OscBundleElementType BundleElementType { get; }
    }
}
