// Copyright (C) Mark Alan Jones 2010
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
    public class OscUdpIoDevice : IOscIoDevice
    {
        private readonly IPEndPoint _defaultRemoteEndPoint;
        private readonly UdpClient _udp;
        private bool _disposed;


        ///<summary>
        ///  Creates a UDP OSC I/O device.
        ///</summary>
        ///<param name = "localEndPoint">Local end point to bind the UDP socket</param>
        ///<param name = "defaultRemoteEndPoint">Default end point to send to if Send does not specify a device channel</param>
        ///<exception cref = "ArgumentNullException"></exception>
        public OscUdpIoDevice(IPEndPoint localEndPoint,
                              IPEndPoint defaultRemoteEndPoint)
        {
            if (localEndPoint == null)
                throw new ArgumentNullException("localEndPoint");

            if (defaultRemoteEndPoint == null)
                throw new ArgumentNullException("defaultRemoteEndPoint");

            _udp = new UdpClient(localEndPoint) {EnableBroadcast = true};
            _defaultRemoteEndPoint = defaultRemoteEndPoint;
            BeginReceive();
        }

        #region IOscIoDevice Members

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///   Raised when a send operation completes.
        /// </summary>
        public event EventHandler<OscIoDeviceEventArgs> DataSent;

        /// <summary>
        ///   Raised when a packet is received.
        /// </summary>
        public event EventHandler<OscIoDeviceEventArgs> DataReceived;


        /// <summary>
        ///   Raised when an I/O error occurs.
        /// </summary>
        public event EventHandler<OscIoDeviceEventArgs> IoError;

        /// <summary>
        ///   Sends an OSC message to the given UDP address.
        /// </summary>
        public void Send(OscMessage message,
                         OscIoDeviceChannel deviceChannel)
        {
            if (ReferenceEquals(message, null))
                throw new ArgumentNullException("message");

            byte[] packet = message.ToOscPacketArray();
            IPEndPoint ipEndPoint = deviceChannel != null ? deviceChannel.IPEndPoint : _defaultRemoteEndPoint;
            OscIoDeviceEventArgs eventArgs = new OscIoDeviceEventArgs(message,
                                                                      new OscIoDeviceChannel(
                                                                          OscIoDeviceChannelType.Udp,
                                                                          ipEndPoint));
            // send message
            _udp.BeginSend(packet, packet.Length, ipEndPoint, OnSend, eventArgs);
        }

        /// <summary>
        ///   Sends a OSC bundle to the given UDP address.
        /// </summary>
        public void Send(OscBundle bundle,
                         OscIoDeviceChannel deviceChannel)
        {
            if (ReferenceEquals(bundle, null))
                throw new ArgumentNullException("bundle");

            byte[] packet = bundle.ToOscPacketArray();
            IPEndPoint ipEndPoint = deviceChannel != null ? deviceChannel.IPEndPoint : _defaultRemoteEndPoint;
            OscIoDeviceEventArgs eventArgs = new OscIoDeviceEventArgs(bundle,
                                                                      new OscIoDeviceChannel(
                                                                          OscIoDeviceChannelType.Udp,
                                                                          ipEndPoint));
            //send bundle
            _udp.BeginSend(packet, packet.Length, ipEndPoint, OnSend, eventArgs);
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
                if (DataSent != null)
                {
                    DataSent(this, eventArgs);
                }
            }
            catch (Exception e)
            {
                eventArgs.Exception = e;

                // raise I/O error
                if (IoError != null)
                {
                    IoError(this, eventArgs);
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
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] datagram = _udp.EndReceive(ar, ref remoteEndPoint);
                //                Console.WriteLine("OnReceive");
                //                Console.WriteLine(Encoding.ASCII.GetString(datagram));

                // create an device address for the remote end point
                OscIoDeviceChannel deviceAddress = new OscIoDeviceChannel(OscIoDeviceChannelType.Udp, remoteEndPoint);

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
                if (DataReceived != null)
                {
                    DataReceived(this, eventArgs);
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
