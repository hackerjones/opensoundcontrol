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
            udp.Send(p1, addr);

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
