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
using System.Text.RegularExpressions;

namespace OpenSoundControl
{
    public static class OscPacket
    {

        /// <summary>
        /// Tries to parse the given array for a valid OSC bundle.
        /// </summary>
        public static bool TryParseBundle(
            byte[] packet,
            out OscBundle bundle
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Tries to parse the given array for a valid OSC message.
        /// </summary>
        public static bool TryParseMessage(
            byte[] packet,
            out OscMessage message
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculates a 32-bit aligned size for the given input size.
        /// </summary>
        public static int PadSize(
            int size
            )
        {
            int n = size % 4;
            if (n == 0)
                return size;
            else
                return (size + (4 - n));
        }

        /// <summary>
        /// Pads the given input array so that it is 32-bit aligned.
        /// </summary>
        public static void PadArray(
            ref byte[] buffer
            )
        {
            int rawSize = buffer.Length;
            int padSize = PadSize(rawSize);
            Array.Resize<byte>(ref buffer, padSize);
        }

        /// <summary>
        /// Converts an OSC bundle into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(
            OscBundle bundle
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts an OSC message into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(
            OscMessage message
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts an OSC string type into a packet byte array.
        /// </summary>
        /// <returns>Packet IO device ready byte array</returns>
        public static byte[] GetBytes(
            OscString str
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts a 32-bit OSC float into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(
            OscFloat32 f
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts a 32-bit OSC signed integer into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(
            OscInt32 n
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts a 32-bit OSC unsigned integer into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(
            OscUInt32 n
            )
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts an OSC blob type into a packet byte array.
        /// </summary>
        public static byte[] GetBytes(
            OscBlob blob
            )
        {
            throw new System.NotImplementedException();
        }

    }
}
