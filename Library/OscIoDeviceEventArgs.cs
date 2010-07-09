// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;

namespace OpenSoundControl
{
    /// <summary>
    ///   Encapsulates packet IO event arguments
    /// </summary>
    public class OscIoDeviceEventArgs : EventArgs
    {
        /// <summary>
        ///   Creates a I/O event argument object which contains an OSC bundle.
        /// </summary>
        public OscIoDeviceEventArgs(OscBundle bundle,
                                    OscIoDeviceAddress deviceAddress,
                                    Exception exception = null)
        {
            Bundle = bundle;
            DeviceAddress = deviceAddress;
            Exception = exception;
        }

        /// <summary>
        ///   Creates a I/O event argument object which contains an OSC message.
        /// </summary>
        public OscIoDeviceEventArgs(OscMessage message,
                                    OscIoDeviceAddress deviceAddress,
                                    Exception exception = null)
        {
            Message = message;
            DeviceAddress = deviceAddress;
            Exception = exception;
        }

        /// <summary>
        ///   Gets an exception if one occurred.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        ///   Gets the device address.
        /// </summary>
        public OscIoDeviceAddress DeviceAddress { get; set; }

        /// <summary>
        ///   Gets the contained message.
        /// </summary>
        public OscMessage Message { get; set; }

        /// <summary>
        ///   Gets the contained bundle.
        /// </summary>
        public OscBundle Bundle { get; set; }

        /// <summary>
        ///   Gets if the event contains a bundle
        /// </summary>
        public bool ContainsBundle
        {
            get { return !ReferenceEquals(Bundle, null); }
        }

        /// <summary>
        ///   Gets if the event contains a message
        /// </summary>
        public bool ContainsMessage
        {
            get { return !ReferenceEquals(Message, null); }
        }

        /// <summary>
        ///   Gets if the event contains an exception
        /// </summary>
        public bool ContainsException
        {
            get { return !ReferenceEquals(Exception, null); }
        }
    }
}
