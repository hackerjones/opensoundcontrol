﻿// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;
using System.Net;
using System.Net.Sockets;

namespace OpenSoundControl
{
    /// <summary>
    ///   Contains methods for sending and receiving OSC packets over UDP.
    /// </summary>
    public class OscUdpIoDevice : IDisposable, IOscIoDevice
    {
        private readonly IPEndPoint _remoteEndPoint;
        private readonly UdpClient _udp;
        private bool _disposed;

        /// <summary>
        ///   Creates a UDP I/O device.
        /// </summary>
        public OscUdpIoDevice(IPEndPoint localEndPoint,
                              IPEndPoint remoteEndPoint)
        {
            _udp = new UdpClient(localEndPoint) {EnableBroadcast = true};
            _remoteEndPoint = remoteEndPoint;
            BeginReceive();
        }

        #region IDisposable Members

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IOscIoDevice Members

        /// <summary>
        ///   Raised when a send operation completes.
        /// </summary>
        public event EventHandler<OscIoDeviceEventArgs> SendCompleted;

        /// <summary>
        ///   Raised when a packet is received.
        /// </summary>
        public event EventHandler<OscIoDeviceEventArgs> ReceiveCompleted;


        /// <summary>
        ///   Raised when an I/O error occurs.
        /// </summary>
        public event EventHandler<OscIoDeviceEventArgs> Error;

        /// <summary>
        ///   Sends an OSC message to the given UDP address.
        /// </summary>
        public void Send(OscMessage message)
        {
            if (ReferenceEquals(message, null))
                throw new ArgumentNullException("message");

            byte[] packet = message.ToOscPacketArray();
            OscIoDeviceEventArgs eventArgs = new OscIoDeviceEventArgs(message,
                                                                      new OscIoDeviceAddress(
                                                                          OscIoDeviceAddressType.Udp, _remoteEndPoint));
            _udp.BeginSend(packet, packet.Length, _remoteEndPoint, OnSend, eventArgs);
        }

        /// <summary>
        ///   Sends a OSC bundle to the given UDP address.
        /// </summary>
        public void Send(OscBundle bundle)
        {
            if (bundle == null)
                throw new ArgumentNullException("bundle");

            byte[] packet = bundle.ToOscPacketArray();
            OscIoDeviceEventArgs eventArgs = new OscIoDeviceEventArgs(bundle,
                                                                      new OscIoDeviceAddress(
                                                                          OscIoDeviceAddressType.Udp, _remoteEndPoint));
            _udp.BeginSend(packet, packet.Length, _remoteEndPoint, OnSend, eventArgs);
        }

        #endregion

        /// <summary>
        ///   Allows an <see cref = "T:System.Object" /> to attempt to free resources and perform other cleanup operations before the <see cref = "T:System.Object" /> is reclaimed by garbage collection.
        /// </summary>
        ~OscUdpIoDevice()
        {
            Dispose(false);
        }

        private void OnSend(IAsyncResult ar)
        {
            var eventArgs = (OscIoDeviceEventArgs)ar.AsyncState;
            try
            {
                _udp.EndSend(ar);

                // raise send event
                if (SendCompleted != null)
                {
                    SendCompleted(this, eventArgs);
                }
            }
            catch (Exception e)
            {
                eventArgs.Exception = e;

                // raise I/O error
                if (Error != null)
                {
                    Error(this, eventArgs);
                }
            }
        }

        private void BeginReceive()
        {
            _udp.BeginReceive(OnReceive, null);
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                // get the datagram
                var remoteEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] datagram = _udp.EndReceive(ar, ref remoteEP);
                //                Console.WriteLine("OnReceive");
                //                Console.WriteLine(Encoding.ASCII.GetString(datagram));

                // create an device address for the remote end point
                var deviceAddress = new OscIoDeviceAddress(OscIoDeviceAddressType.Udp, remoteEP);

                IOscElement element = OscParser.Parse(datagram);
                OscIoDeviceEventArgs eventArgs = null;
                switch (element.ElementType)
                {
                    case OscElementType.Message:
                        eventArgs = new OscIoDeviceEventArgs(element as OscMessage, deviceAddress);
                        break;
                    case OscElementType.Bundle:
                        eventArgs = new OscIoDeviceEventArgs(element as OscBundle, deviceAddress);
                        break;
                }

                // raise receive event
                if (ReceiveCompleted != null)
                {
                    ReceiveCompleted(this, eventArgs);
                }
            }
            finally
            {
                BeginReceive();
            }
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _udp.Close();
                }
            }

            _disposed = true;
        }
    }
}
