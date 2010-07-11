// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;

namespace OpenSoundControl
{
    /// <summary>
    ///   I/O device interface
    /// </summary>
    public interface IOscIoDevice : IDisposable
    {
        /// <summary>
        ///   Raised when a send operation completes.
        /// </summary>
        event EventHandler<OscIoDeviceEventArgs> SendCompleted;

        /// <summary>
        ///   Raised when a packet is received.
        /// </summary>
        event EventHandler<OscIoDeviceEventArgs> ReceiveCompleted;

        /// <summary>
        ///   Raised when an I/O error occurs.
        /// </summary>
        event EventHandler<OscIoDeviceEventArgs> Error;

        /// <summary>
        ///   Sends an OSC message to the given device address.
        /// </summary>
        /// <param name = "message">OSC message to send.</param>
        void Send(OscMessage message);

        /// <summary>
        ///   Sends a OSC bundle to the given device address.
        /// </summary>
        /// <param name = "bundle">OSC bundle to send.</param>
        void Send(OscBundle bundle);
    }
}
