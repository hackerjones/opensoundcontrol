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
                                              new IPEndPoint(IPAddress.Parse("192.168.0.106"), 10000));
            
            udp.SendCompleted += SendCompleted;
            udp.ReceiveCompleted += ReceiveCompleted;

            var p1 = new OscMessage("/servo/0/position 512");            
            var p2 = new OscMessage("/servo/1/position 512");
            var p3 = new OscMessage("/servo/0/position 0");
            var p4 = new OscMessage("/servo/1/position 0");

            while (true)
            {
                udp.Send(p1, addr);
                udp.Send(p2, addr);
                Thread.Sleep(1000);
                udp.Send(p3, addr);
                udp.Send(p4, addr);
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
                
            }
        }
    }
}
