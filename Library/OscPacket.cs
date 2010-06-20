using System;
using System.Net;
using System.Text;

namespace OpenSoundControl
{
    internal static class OscPacket
    {
        /// <summary>
        /// Calculates an OSC padded size from a given input size.
        /// </summary>
        /// <remarks>
        /// OSC requires data items to be 32-bit or 4 byte aligned. 
        /// This function is called with the size of an item and will return
        /// a new number of bytes the item should be for proper alignment.
        /// </remarks>        
        public static int PadSize(int size)
        {
            int n = size % 4;
            if (n == 0)
                return size;
            else
                return (size + (4 - n));
        }

        /// <summary>
        /// Pads the array to properly align it for transmission inside an OSC packet.
        /// </summary>        
        public static byte[] PadArray(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");

            int rawSize = buffer.Length;
            int padSize = PadSize(rawSize);

            // padding not required
            if (rawSize == padSize)
                return buffer;

            var newBuffer = new byte[padSize];
            buffer.CopyTo(newBuffer, 0);
            return newBuffer;
        }

        public static byte[] ToPacketArray(int ho)
        {
            int no = IPAddress.HostToNetworkOrder(ho);
            unsafe
            {
                var buffer = new byte[4];
                var ptr = (byte*)&no;

                for (int i = 0; i < 4; i++)
                {
                    buffer[i] = ptr[i];
                }
                return buffer;
            }
        }

        public static byte[] ToPacketArray(uint ho)
        {
            return ToPacketArray((int)ho);
        }

        public static byte[] ToPacketArray(float ho)
        {
            return ToPacketArray((int)ho);
        }

        public static IOscElement Parse(byte[] packet)
        {
            if (packet == null) throw new ArgumentNullException("packet");

            if (IsBundle(packet))
            {
                return ParseBundle(packet);
            }
            else
            {
                return ParseMessage(packet);
            }
        }

        /// <summary>
        /// Determines if the packet is a bundle.
        /// </summary>        
        private static bool IsBundle(byte[] packet)
        {
            string packetText = Encoding.ASCII.GetString(packet);
            return packetText.StartsWith("#bundle");
        }

        private static OscMessage ParseMessage(byte[] packet)
        {
            throw new NotImplementedException();
        }

        private static OscBundle ParseBundle(byte[] packet)
        {
            throw new NotImplementedException();
        }
    }
}
