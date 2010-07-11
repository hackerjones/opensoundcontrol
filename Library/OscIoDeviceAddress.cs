// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;
using System.Net;

namespace OpenSoundControl
{
    /// <summary>
    ///   Encapsulates an I/O device address.
    /// </summary>
    public class OscIoDeviceAddress
    {
        private readonly IPEndPoint _ipEndPoint;
        private readonly OscIoDeviceAddressType _type;

        /// <summary>
        ///   Creates a device address for IP address types
        /// </summary>
        /// <param name = "type"></param>
        /// <param name = "ipEndPoint"></param>
        /// <exception cref = "ArgumentException"></exception>
        public OscIoDeviceAddress(OscIoDeviceAddressType type,
                                  IPEndPoint ipEndPoint)
        {
            if (type != OscIoDeviceAddressType.Udp)
                throw new ArgumentException("Invalid address type for IPEndPoint");

            _type = type;
            _ipEndPoint = ipEndPoint;
        }

        /// <summary>
        ///   Gets the device address type.
        /// </summary>
        public OscIoDeviceAddressType Type
        {
            get { return _type; }
        }

        /// <summary>
        ///   Gets the device address as an IPEndPoint.
        /// </summary>
        public IPEndPoint IPEndPoint
        {
            get
            {
                if (_type != OscIoDeviceAddressType.Udp)
                    throw new InvalidOperationException("Address is not an IP type");

                return _ipEndPoint;
            }
        }
    }
}
