/*
 * Copyright (C) Mark Alan Jones 2010
 * This code is published under the Microsoft Public License (Ms-Pl)
 * A copy of the Ms-Pl license is included with the source and 
 * binary distributions or online at
 * http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    /// Methods for creating and parsing OSC packets
    /// </summary>
    public static class OscPacket
    {
        /// <summary>
        /// Tries to parse the given array for a valid OSC bundle.
        /// </summary>
        public static bool TryParseBundle(byte[] packet,
                                          out OscBundle bundle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tries to parse the given array for a valid OSC message.
        /// </summary>
        public static bool TryParseMessage(byte[] packet,
                                           out OscMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates a 32-bit aligned size for the given input size.
        /// </summary>
        public static int PadSize(int size)
        {
            int n = size % 4;
            if (n == 0)
                return size;

            return (size + (4 - n));
        }

        /// <summary>
        /// Pads the given input array so that it is 32-bit aligned.
        /// </summary>
        /// <remarks>If the array needs to be resized for alignment this function does not alter the input array.
        /// It instead creates a new aligned array and copies the input array to the new array.</remarks>
        /// <returns>32-bit aligned copy of the input array</returns>
        public static byte[] PadArray(byte[] buffer)
        {
            int rawSize = buffer.Length;
            int padSize = PadSize(rawSize);
            if (padSize == rawSize)
                return buffer;
            var newBuffer = new byte[padSize];
            buffer.CopyTo(newBuffer, 0);
            return newBuffer;
        }

        /// <summary>
        /// Converts an OSC bundle into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(OscBundle bundle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts an OSC message into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(OscMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts an OSC string type into a packet byte array.
        /// </summary>
        /// <returns>Packet IO device ready byte array</returns>
        public static byte[] GetBytes(OscString str)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(str.Value);
            buffer = PadArray(buffer);
            return buffer;
        }

        /// <summary>
        /// Converts a 32-bit OSC float into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(OscFloat32 f)
        {
            return GetBytes(IPAddress.HostToNetworkOrder((int)f.Value));
        }

        /// <summary>
        /// Converts a 32-bit OSC signed integer into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(OscInt32 n)
        {
            return GetBytes(IPAddress.HostToNetworkOrder(n.Value));
        }

        /// <summary>
        /// Converts a 32-bit OSC unsigned integer into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(OscUInt32 n)
        {
            return GetBytes(IPAddress.HostToNetworkOrder((int)n.Value));
        }

        /// <summary>
        /// Converts an OSC blob type into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(OscBlob blob)
        {
            var buffer = new List<byte>();

            // 4 bytes of size
            buffer.AddRange(GetBytes(blob.Buffer.Count));

            // size bytes of data
            buffer.AddRange(PadArray(blob.Buffer.ToArray()));

            return buffer.ToArray();
        }

        /// <summary>
        /// Converts a 32-bit value into a byte array.
        /// </summary>
        private static byte[] GetBytes(int value)
        {
            var buffer = new byte[4];
            unsafe
            {
                var ptr = (byte*)&value;
                for (int i = 0; i < 4; i++)
                {
                    buffer[i] = ptr[i];
                }
            }
            return buffer;
        }
    }
}
