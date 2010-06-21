using System;
using System.Net;
using System.Text;

namespace OpenSoundControl
{
    internal static class OscPacket
    {
        /// <summary>
        ///   Calculates an OSC padded size from a given input size.
        /// </summary>
        /// <remarks>
        ///   OSC requires data items to be 32-bit or 4 byte aligned. 
        ///   This function is called with the size of an item and will return
        ///   a new number of bytes the item should be for proper alignment.
        /// </remarks>
        public static int PadSize(int size)
        {
            int n = size % 4;
            return n == 0 ? size : size + (4 - n);
        }

        /// <summary>
        ///   Pads the array to properly align it for transmission inside an OSC packet.
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

        /// <summary>
        ///   Parses a packet.
        /// </summary>
        public static IOscElement Parse(byte[] packet)
        {
            if (packet == null) throw new ArgumentNullException("packet");

            return IsBundle(packet) ? (IOscElement)ParseBundle(packet) : ParseMessage(packet);
        }

        /// <summary>
        ///   Determines if the packet is a bundle.
        /// </summary>
        private static bool IsBundle(byte[] packet)
        {
            string packetText = Encoding.ASCII.GetString(packet);
            return packetText.StartsWith("#bundle");
        }

        /// <summary>
        ///   Parses a message packet.
        /// </summary>
        private static OscMessage ParseMessage(byte[] packet)
        {
            uint packetIndex = 0;

            OscAddress addr = ExtractAddress(packet, ref packetIndex);
            OscTypeTagString typeTagString = ExtractTypeTagString(packet, ref packetIndex);
        }

        /// <summary>
        ///   Extracts an address from a message packet.
        /// </summary>
        private static OscAddress ExtractAddress(byte[] packet,
                                                 ref uint packetIndex)
        {
            string packetText = Encoding.ASCII.GetString(packet, (int)packetIndex, packet.Length - (int)packetIndex);
            int left = packetText.IndexOf('/');
            int right = packetText.IndexOf(',');
            packetIndex = (uint)right;
            string addrText = packetText.Substring(left, right - left);
            return new OscAddress(addrText);
        }

        /// <summary>
        ///   Extracts a type tag string from a packet.
        /// </summary>
        private static OscTypeTagString ExtractTypeTagString(byte[] packet,
                                                             ref uint packetIndex)
        {
        }

        /// <summary>
        ///   Parses a bundle packet.
        /// </summary>
        private static OscBundle ParseBundle(byte[] packet)
        {
            uint packetIndex = 8; // skip #bundle

            var bundle = new OscBundle
                             {
                                 Timetag = ExtractTimetag(packet, ref packetIndex)
                             };

            do
            {
                uint size = ExtractBundleElementSize(packet, ref packetIndex);
                byte[] element = ExtractBundleElement(packet, ref packetIndex, size);
                if (IsBundle(element))
                {
                    ParseBundle(element);
                }
                else
                {
                    ParseMessage(element);
                }
            } while (packetIndex < packet.Length);

            return null;
        }

        /// <summary>
        ///   Extracts a timetag from a packet.
        /// </summary>
        private static unsafe OscTimetag ExtractTimetag(byte[] packet,
                                                        ref uint packetIndex)
        {
            ulong tmp64;
            var tmp64Ptr = (byte*)&tmp64;

            for (int i = 0; i < 8; i++)
            {
                tmp64Ptr[i] = packet[packetIndex];
                packetIndex++;
            }
            tmp64 = (ulong)IPAddress.NetworkToHostOrder((long)tmp64);
            return new OscTimetag(tmp64);
        }

        /// <summary>
        ///   Extracts a size of a bundle element from a packet.
        /// </summary>
        private static unsafe uint ExtractBundleElementSize(byte[] packet,
                                                            ref uint packetIndex)
        {
            uint tmp32;
            var tmp32Ptr = (byte*)&tmp32;

            for (int i = 0; i < 4; i++)
            {
                tmp32Ptr[i] = packet[packetIndex];
                packetIndex++;
            }
            tmp32 = (uint)IPAddress.NetworkToHostOrder((int)tmp32);
            return tmp32;
        }

        /// <summary>
        ///   Extracts a bundle element from a packet.
        /// </summary>
        private static byte[] ExtractBundleElement(byte[] packet,
                                                   ref uint packetIndex,
                                                   uint size)
        {
            var buf = new byte[size];

            Array.Copy(packet, packetIndex, buf, 0, size);
            packetIndex += size;
            return buf;
        }
    }
}
