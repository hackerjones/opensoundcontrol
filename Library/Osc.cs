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
    ///   Utility methods
    /// </summary>
    internal static class Osc
    {
        /// <summary>
        ///   C like memcpy() function.
        /// </summary>
        /// <param name = "dst">Destination pointer</param>
        /// <param name = "src">Source pointer</param>
        /// <param name = "size">Number of elements to copy</param>
        public static unsafe void MemoryCopy(byte* dst,
                                             byte* src,
                                             int size)
        {
            for (int i = 0; i < size; i++)
            {
                dst[i] = src[i];
            }
        }

        /// <summary>
        ///   Extension method for returning a OSC ready array from an signed integer
        /// </summary>
        /// <param name = "ho">integer in host order</param>
        /// <returns></returns>
        public static byte[] ToOscPacketArray(this int ho)
        {
            int no = IPAddress.HostToNetworkOrder(ho);
            byte[] buffer = new byte[4];
            unsafe
            {
                fixed (byte* dst = buffer)
                {
                    MemoryCopy(dst, (byte*)&no, buffer.Length);
                }
            }
            return buffer;
        }

        /// <summary>
        ///   Extension method for returning a OSC ready array from an unsigned integer
        /// </summary>
        /// <param name = "ho">integer in host order</param>
        /// <returns></returns>
        public static byte[] ToOscPacketArray(this uint ho)
        {
            return ToOscPacketArray((int)ho);
        }

        /// <summary>
        ///   Extension method for returning a OSC ready array from an float
        /// </summary>
        /// <param name = "ho">float in host order</param>
        /// <returns></returns>
        public static byte[] ToOscPacketArray(this float ho)
        {
            return ToOscPacketArray((int)ho);
        }

        /// <summary>
        ///   Calculates an OSC padded size from a given input size.
        /// </summary>
        /// <remarks>
        ///   OSC requires data items to be 32-bit or 4 byte aligned. 
        ///   This function is called with the size of an item and will return
        ///   a new number of bytes the item should be for proper alignment.
        /// </remarks>
        /// <param name = "size">Unpadded size</param>
        /// <returns>Padded size</returns>
        public static int PadSize(int size)
        {
            int n = size % 4;
            return n == 0 ? size : size + (4 - n);
        }

        /// <summary>
        ///   Pads the array to properly align it for transmission inside an OSC packet.
        /// </summary>
        /// <param name = "buffer">Unpadded array</param>
        /// <returns>Padded array</returns>
        public static byte[] PadArray(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            int rawSize = buffer.Length;
            int padSize = PadSize(rawSize);

            // padding not required
            if (rawSize == padSize)
            {
                return buffer;
            }

            byte[] newBuffer = new byte[padSize];
            buffer.CopyTo(newBuffer, 0);
            return newBuffer;
        }
    }
}
