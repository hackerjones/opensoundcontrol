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
    public enum OscPacketIOAddressType
    {
        Udp
    }

    public class OscPacketIODeviceAddress
    {
        private IPEndPoint ipEndPoint;
        private OscPacketIOAddressType type;

        public OscPacketIODeviceAddress(OscPacketIOAddressType type,
                                        IPEndPoint localEP)
        {
            if (type != OscPacketIOAddressType.Udp)
            {
                throw new ArgumentException("Invalid address type for IPEndPoint");
            }
            this.type = type;
            ipEndPoint = localEP;
        }
    }
}
