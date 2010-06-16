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
    public interface IOscPacketIODevice
    {
        /// <summary>
        /// Raised when a send operation completes.
        /// </summary>
        event EventHandler<OscPacketIOEventArgs> SendCompleted;

        /// <summary>
        /// Raised when a packet is received.
        /// </summary>
        event EventHandler<OscPacketIOEventArgs> ReceiveCompleted;

        /// <summary>
        /// Sends an OSC message to the given device address.
        /// </summary>
        /// <param name="message">OSC message to send.</param>
        /// <param name="deviceAddress">Device address to send to.</param>
        void Send(
            OscMessage message,
            OscPacketIODeviceAddress deviceAddress
            );

        /// <summary>
        /// Sends a OSC bundle to the given device address.
        /// </summary>
        /// <param name="bundle">OSC bundle to send.</param>
        /// <param name="deviceAddress">Device address to send to.</param>
        void Send(
            OscBundle bundle,
            OscPacketIODeviceAddress deviceAddress
            );
    }
}
