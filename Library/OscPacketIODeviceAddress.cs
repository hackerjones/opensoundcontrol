/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;
using System.Net;

namespace OpenSoundControl
{
    /// <summary>
    /// Packet IO address type enumeration.
    /// </summary>
    public enum OscPacketIOAddressType
    {
        Udp
    }

    /// <summary>
    /// Encapsulates a packet IO device address.
    /// </summary>
    public class OscPacketIODeviceAddress
    {
        private readonly IPEndPoint _ipEndPoint;
        private OscPacketIOAddressType type;

        public OscPacketIODeviceAddress(OscPacketIOAddressType type,
                                        IPEndPoint localEP)
        {
            if (type != OscPacketIOAddressType.Udp)
            {
                throw new ArgumentException("Invalid address type for IPEndPoint");
            }
            this.type = type;
            _ipEndPoint = localEP;
        }

        /// <summary>
        /// Gets the device address type.
        /// </summary>
        public OscPacketIOAddressType Type
        {
            get { return type; }
        }

        /// <summary>
        /// Gets the device address as an IPEndPoint.
        /// </summary>
        public IPEndPoint IPEndPoint
        {
            get { return _ipEndPoint; }
        }
    }
}
