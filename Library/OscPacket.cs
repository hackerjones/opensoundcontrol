using System;
using System.Collections.Generic;
using System.Linq;
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
            int packetIndex = 0;

            var msg = new OscMessage
                          {
                              Address = ParseAddress(packet, ref packetIndex),
                              Arguments =
                                  ParseArguments(packet, ref packetIndex)
                          };

            return msg;
        }

        private static List<IOscElement> ParseArguments(byte[] packet,
                                                        ref int packetIndex)
        {
            OscTypeTagString typeTagString = ParseTypeTagString(packet, ref packetIndex);
            var args = new List<IOscElement>();

            foreach (OscElementType elementType in typeTagString.Arguments)
            {
                switch (elementType)
                {
                    case OscElementType.Int32:
                        break;
                    case OscElementType.UInt32:
                        break;
                    case OscElementType.Float32:
                        break;
                    case OscElementType.String:
                        args.Add(ParseString(packet, ref packetIndex));
                        break;
                    case OscElementType.Blob:
                        break;
                    case OscElementType.True:
                        args.Add(new OscTrue());
                        break;
                    case OscElementType.False:
                        args.Add(new OscFalse());
                        break;
                    case OscElementType.Null:
                        args.Add(new OscNull());
                        break;
                    case OscElementType.Impulse:
                        args.Add(new OscImpulse());
                        break;
                    case OscElementType.Timetag:
                        args.Add(ParseTimetag(packet, ref packetIndex));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return args;
        }

        /// <summary>
        ///   Parse an address from a message packet.
        /// </summary>
        private static OscAddress ParseAddress(byte[] packet,
                                               ref int packetIndex)
        {
            string packetText = Encoding.ASCII.GetString(packet, packetIndex, packet.Length - packetIndex);
            int left = packetText.IndexOf('/');
            int right = packetText.IndexOf(',');
            packetIndex = right;
            string addrText = packetText.Substring(left, right - left);
            return new OscAddress(addrText);
        }

        /// <summary>
        ///   Parses a type tag string from a packet.
        /// </summary>
        private static OscTypeTagString ParseTypeTagString(byte[] packet,
                                                           ref int packetIndex)
        {
            if (packet[packetIndex] != ',')
                throw new ArgumentException(String.Format("packet[{0}] != ','", packetIndex));

            return new OscTypeTagString(ParseString(packet, ref packetIndex).ToString());
        }

        /// <summary>
        ///   Parses a string from a packet.
        /// </summary>
        private static OscString ParseString(byte[] packet,
                                             ref int packetIndex)
        {
            string packetText = Encoding.ASCII.GetString(packet, packetIndex, packet.Length - packetIndex);
            var str = new string(packetText.TakeWhile(i => i != '\0').ToArray());
            packetIndex += PadSize(str.Length);
            return new OscString(str);
        }

        /// <summary>
        ///   Parses a bundle packet.
        /// </summary>
        private static OscBundle ParseBundle(byte[] packet)
        {
            int packetIndex = 8; // skip #bundle

            var bundle = new OscBundle
                             {
                                 Timetag = ParseTimetag(packet, ref packetIndex)
                             };

            do
            {
                int size = ParseBundleElementSize(packet, ref packetIndex);
                byte[] element = ParseBundleElement(packet, ref packetIndex, size);
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
        ///   Parses a timetag from a packet.
        /// </summary>
        private static unsafe OscTimetag ParseTimetag(byte[] packet,
                                                      ref int packetIndex)
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
        ///   Parses a size of a bundle element from a packet.
        /// </summary>
        private static unsafe int ParseBundleElementSize(byte[] packet,
                                                         ref int packetIndex)
        {
            int tmp32;
            var tmp32Ptr = (byte*)&tmp32;

            for (int i = 0; i < 4; i++)
            {
                tmp32Ptr[i] = packet[packetIndex];
                packetIndex++;
            }
            tmp32 = IPAddress.NetworkToHostOrder(tmp32);
            return tmp32;
        }

        /// <summary>
        ///   Parses a bundle element from a packet.
        /// </summary>
        private static byte[] ParseBundleElement(byte[] packet,
                                                 ref int packetIndex,
                                                 int size)
        {
            var buf = new byte[size];

            Array.Copy(packet, packetIndex, buf, 0, size);
            packetIndex += size;
            return buf;
        }
    }
}
