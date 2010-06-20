using OpenSoundControl;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            OscMessage msg = new OscMessage("    /servo/0/position 512");
        }
    }
}
