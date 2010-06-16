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
    public class OscPacketIOEventArgs : EventArgs
    {
        private OscPacketIODeviceAddress deviceAddress;
        /// <summary>
        /// </summary>
        private OscBundle bundle;
        private OscMessage message;

        public OscPacketIOEventArgs(OscBundle bundle, OscPacketIODeviceAddress deviceAddress)
        {            
            this.deviceAddress = deviceAddress;
            this.bundle = bundle;
        }

        public OscPacketIOEventArgs(OscMessage message, OscPacketIODeviceAddress deviceAddress)
        {
            this.deviceAddress = deviceAddress;
            this.message = message;
        }

        public OscPacketIODeviceAddress DeviceAddress
        {
            get
            {
                return deviceAddress;
            }
        }

        /// <summary>
        /// True if a bundle is contained in the event
        /// </summary>
        public bool IsBundle
        {
            get
            {
                return bundle != null;
            }            
        }

        /// <summary>
        /// True if a message is contained in the event
        /// </summary>
        public bool IsMessage
        {
            get
            {
                return message != null;
            }            
        }
    }
}
