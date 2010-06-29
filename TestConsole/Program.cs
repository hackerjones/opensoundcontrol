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
            var udp = new OscUdpIoDevice(10000);
            var addr = new OscIoDeviceAddress(OscIoDeviceAddressType.Udp,
                                              new IPEndPoint(IPAddress.Parse("192.168.0.100"), 10000));
            var p1 = new OscMessage("/");
            udp.SendCompleted += SendCompleted;
            udp.ReceiveCompleted += ReceiveCompleted;
            udp.Send(p1, addr);

            while (true)
            {
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
            Console.WriteLine("HasBundle {0}", args.HasBundle);
            Console.WriteLine("HasMessage {0}", args.HasMessage);
        }
    }
}
