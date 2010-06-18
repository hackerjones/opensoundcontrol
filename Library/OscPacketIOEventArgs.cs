/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;

namespace OpenSoundControl
{
    /// <summary>
    /// Encapsulates packet IO event arguments
    /// </summary>
    public class OscPacketIOEventArgs : EventArgs
    {
        private readonly OscBundle _bundle;

        private readonly OscPacketIODeviceAddress _deviceAddress;

        private readonly OscMessage _message;

        /// <summary>
        /// Creates a packet IO event argument object which contains an OSC bundle.
        /// </summary>
        public OscPacketIOEventArgs(OscBundle bundle,
                                    OscPacketIODeviceAddress deviceAddress)
        {
            _deviceAddress = deviceAddress;
            _bundle = bundle;
        }

        /// <summary>
        /// Creates a packet IO event argument object which contains an OSC message.
        /// </summary>
        public OscPacketIOEventArgs(OscMessage message,
                                    OscPacketIODeviceAddress deviceAddress)
        {
            _deviceAddress = deviceAddress;
            _message = message;
        }

        /// <summary>
        /// Gets the device address.
        /// </summary>        
        public OscPacketIODeviceAddress DeviceAddress
        {
            get { return _deviceAddress; }
        }

        /// <summary>
        /// Gets if the event contains a bundle
        /// </summary>
        public bool IsBundle
        {
            get { return _bundle != null; }
        }

        /// <summary>
        /// Gets if the event contains a message
        /// </summary>
        public bool IsMessage
        {
            get { return _message != null; }
        }
    }
}
