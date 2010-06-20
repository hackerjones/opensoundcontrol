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
    /// Element interface.
    /// </summary>
    public interface IOscElement
    {
        /// <summary>
        /// Gets the element type.
        /// </summary>        
        OscElementType ElementType { get; }

        /// <summary>
        ///  True if the element is also an argument
        /// </summary>
        bool IsArgument { get; }

        /// <summary>
        /// Gets the packet array data for the element.
        /// </summary>        
        byte[] ToPacketArray();
    }
}
