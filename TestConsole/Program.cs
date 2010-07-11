// Copyright (C) Mark Alan Jones 2010
// This code is published under the Microsoft Public License (Ms-Pl)
// A copy of the Ms-Pl license is included with the source and 
// binary distributions or online at
// http://www.microsoft.com/opensource/licenses.mspx#Ms-PL
using System;
using System.Net;
using System.Threading;
using OpenSoundControl;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var udp = new OscUdpIoDevice(new IPEndPoint(IPAddress.Any, 10000),
                                         new IPEndPoint(IPAddress.Parse("255.255.255.255"), 10000));

            udp.SendCompleted += SendCompleted;
            udp.ReceiveCompleted += ReceiveCompleted;

            var p1 = new OscMessage("/servo/0/position 512");
            var p2 = new OscMessage("/servo/1/position 512");
            var p3 = new OscMessage("/servo/0/position 0");
            var p4 = new OscMessage("/servo/1/position 0");

            while (true)
            {
                udp.Send(p1);
                udp.Send(p2);
                Thread.Sleep(1000);
                udp.Send(p3);
                udp.Send(p4);
                Thread.Sleep(1000);
            }
        }

        private static void SendCompleted(object sender,
                                          OscIoDeviceEventArgs args)
        {
            Console.WriteLine("SendCompleted");
        }

        private static void ReceiveCompleted(object sender,
                                             OscIoDeviceEventArgs args)
        {
            Console.WriteLine("Receive from {0}", args.DeviceAddress.IPEndPoint);
            if (args.ContainsBundle)
            {
                Console.WriteLine(args.Bundle.ToString());
            }

            if (args.ContainsMessage)
            {
                Console.WriteLine(args.Message.ToString());
            }
        }
    }
}
