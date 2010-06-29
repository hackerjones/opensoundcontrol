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
using System.Net;
using System.Text;

namespace OpenSoundControl
{
    /// <summary>
    ///   Methods for parsing an OSC packet
    /// </summary>
    internal static class OscParser
    {
        /// <summary>
        ///   Parses a packet.
        /// </summary>
        public static IOscElement Parse(byte[] packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException("packet");
            }

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

            OscMessage msg = new OscMessage
                                 {
                                     Address = ParseAddress(packet, ref packetIndex),
                                     Arguments =
                                         ParseArguments(packet, ref packetIndex)
                                 };

            return msg;
        }

        /// <summary>
        ///   Parses arguments from a message packet.
        /// </summary>
        private static List<IOscElement> ParseArguments(byte[] packet,
                                                        ref int packetIndex)
        {
            // get the type tag string
            OscTypeTagString typeTagString = ParseTypeTagString(packet, ref packetIndex);

            // parse and store arguments in a list
            List<IOscElement> arguments = new List<IOscElement>();
            foreach (OscElementType elementType in typeTagString.Arguments)
            {
                switch (elementType)
                {
                    case OscElementType.Int32:
                        arguments.Add(ParseInt32(packet, ref packetIndex));
                        break;
                    case OscElementType.UInt32:
                        arguments.Add(ParseUInt32(packet, ref packetIndex));
                        break;
                    case OscElementType.Float32:
                        arguments.Add(ParseFloat32(packet, ref packetIndex));
                        break;
                    case OscElementType.String:
                        arguments.Add(ParseString(packet, ref packetIndex));
                        break;
                    case OscElementType.Blob:
                        break;
                    case OscElementType.True:
                        arguments.Add(new OscTrue());
                        break;
                    case OscElementType.False:
                        arguments.Add(new OscFalse());
                        break;
                    case OscElementType.Null:
                        arguments.Add(new OscNull());
                        break;
                    case OscElementType.Impulse:
                        arguments.Add(new OscImpulse());
                        break;
                    case OscElementType.Timetag:
                        arguments.Add(ParseTimetag(packet, ref packetIndex));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return arguments;
        }

        private static unsafe OscFloat32 ParseFloat32(byte[] packet,
                                                      ref int packetIndex)
        {
            float tmp;

            byte* dstPtr = (byte*)(&tmp);
            fixed (byte* srcPtr = &packet[packetIndex])
            {
                Osc.MemoryCopy(dstPtr, srcPtr, 4);
            }
            packetIndex += 4;

            return new OscFloat32(IPAddress.NetworkToHostOrder((int)tmp));
        }

        private static unsafe OscInt32 ParseInt32(byte[] packet,
                                                  ref int packetIndex)
        {
            int tmp;

            byte* dstPtr = (byte*)(&tmp);
            fixed (byte* srcPtr = &packet[packetIndex])
            {
                Osc.MemoryCopy(dstPtr, srcPtr, 4);
            }
            packetIndex += 4;

            return new OscInt32(IPAddress.NetworkToHostOrder(tmp));
        }

        private static unsafe OscUInt32 ParseUInt32(byte[] packet,
                                                    ref int packetIndex)
        {
            uint tmp;

            byte* dstPtr = (byte*)(&tmp);
            fixed (byte* srcPtr = &packet[packetIndex])
            {
                Osc.MemoryCopy(dstPtr, srcPtr, 4);
            }
            packetIndex += 4;

            return new OscUInt32((uint)IPAddress.NetworkToHostOrder((int)tmp));
        }

        /// <summary>
        ///   Parse an address from a message packet.
        /// </summary>
        private static OscAddress ParseAddress(byte[] packet,
                                               ref int packetIndex)
        {
            // convert to string
            string packetText = Encoding.ASCII.GetString(packet, packetIndex, packet.Length - packetIndex);

            // cut out the address
            int left = packetText.IndexOf('/');
            int right = packetText.IndexOf(',');
            string addrText = packetText.Substring(left, right - left);

            // move the packet index
            packetIndex += right;

            return new OscAddress(addrText);
        }

        /// <summary>
        ///   Parses a type tag string from a packet.
        /// </summary>
        private static OscTypeTagString ParseTypeTagString(byte[] packet,
                                                           ref int packetIndex)
        {
            // starts with a comma
            if (packet[packetIndex] != ',')
            {
                throw new ArgumentException(String.Format("packet[{0}] != ','", packetIndex));
            }

            return new OscTypeTagString(ParseString(packet, ref packetIndex).ToString());
        }

        /// <summary>
        ///   Parses a string from a packet.
        /// </summary>
        private static OscString ParseString(byte[] packet,
                                             ref int packetIndex)
        {
            // convert to string
            string packetText = Encoding.ASCII.GetString(packet, packetIndex, packet.Length - packetIndex);

            // take characters before the null
            string str = new string(packetText.TakeWhile(i => i != '\0').ToArray());

            // move the packet index by the padded size of the string
            packetIndex += Osc.PadSize(str.Length);

            return new OscString(str);
        }

        /// <summary>
        ///   Parses a bundle packet.
        /// </summary>
        private static OscBundle ParseBundle(byte[] packet)
        {
            int packetIndex = 8; // skip #bundle

            OscBundle bundle = new OscBundle
                                   {
                                       Timetag = ParseTimetag(packet, ref packetIndex)
                                   };

            do
            {
                // get element size
                int size = ParseBundleElementSize(packet, ref packetIndex);

                // get element bytes
                byte[] element = ParseBundleElement(packet, ref packetIndex, size);

                if (IsBundle(element))
                {
                    bundle.Elements.Add(ParseBundle(element));
                }
                else
                {
                    bundle.Elements.Add(ParseMessage(element));
                }
            } while (packetIndex < packet.Length);

            return bundle;
        }

        /// <summary>
        ///   Parses a timetag from a packet.
        /// </summary>
        private static unsafe OscTimetag ParseTimetag(byte[] packet,
                                                      ref int packetIndex)
        {
            ulong tmp64;
            byte* tmp64Ptr = (byte*)&tmp64;

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
            int tmp;
            byte* dstPtr = (byte*)&tmp;
            fixed (byte* srcPtr = &packet[packetIndex])
            {
                Osc.MemoryCopy(dstPtr, srcPtr, 4);
            }
            tmp = IPAddress.NetworkToHostOrder(tmp);
            return tmp;
        }

        /// <summary>
        ///   Parses a bundle element from a packet.
        /// </summary>
        private static byte[] ParseBundleElement(byte[] packet,
                                                 ref int packetIndex,
                                                 int size)
        {
            byte[] buf = new byte[size];

            Array.Copy(packet, packetIndex, buf, 0, size);
            packetIndex += size;
            return buf;
        }
    }
}
