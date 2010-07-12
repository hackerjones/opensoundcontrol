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
    ///   Encapsulates an I/O channel.
    /// </summary>
    public class OscIoDeviceChannel
    {
        private readonly IPEndPoint _ipEndPoint;
        private readonly OscIoDeviceChannelType _type;

        /// <summary>
        ///   Creates a device channel for IP address types
        /// </summary>
        /// <param name = "type"></param>
        /// <param name = "ipEndPoint"></param>
        /// <exception cref = "ArgumentException"></exception>
        public OscIoDeviceChannel(OscIoDeviceChannelType type,
                                  IPEndPoint ipEndPoint)
        {
            switch (type)
            {
                case OscIoDeviceChannelType.Udp:
                    break;
                default:
                    throw new ArgumentException("Channel is not an IP type");
            }

            _type = type;
            _ipEndPoint = ipEndPoint;
        }

        /// <summary>
        ///   Gets the device channel type.
        /// </summary>
        public OscIoDeviceChannelType Type
        {
            get { return _type; }
        }

        /// <summary>
        ///   Gets the device channel as an IPEndPoint.
        /// </summary>
        public IPEndPoint IPEndPoint
        {
            get
            {
                switch (_type)
                {
                    case OscIoDeviceChannelType.Udp:
                        break;
                    default:
                        throw new InvalidOperationException("Channel is not an IP type");
                }

                return _ipEndPoint;
            }
        }
    }
}
