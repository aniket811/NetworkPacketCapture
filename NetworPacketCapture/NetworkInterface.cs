using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkPacketCapture
{
    public class NetworkInterface
    {

        public  static void ListInterface()
        {
            Console.WriteLine("Available Network Interface(s):");
               var devices = SharpPcap.CaptureDeviceList.Instance; // Use the specific class from the chosen namespace

            if (devices.Count < 1)
            {
                Console.WriteLine("No devices found!");
                return;
            }
            //List all network instances
            for(int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine($"{i}: {devices[i].Description}");
            }
            Console.Write("Enter the device index to capture packets: ");
            int deviceIndex = int.Parse(Console.ReadLine() ?? "0");
            if (deviceIndex < 0 || deviceIndex >= devices.Count)
            {
                Console.WriteLine("Invalid index!");
                return;
            }


            var device = devices[deviceIndex];
            Console.Write("Enter the device Packet filter (e.g 'tcp port 80' , 'icmp','src host 192.168.1.1') ");
            var userFilter = Console.ReadLine();

            // Open the device
            device.Open(DeviceModes.Promiscuous);
            if (!String.IsNullOrWhiteSpace(userFilter))
            {
                try
                {
                    device.Filter = userFilter;
                    Console.Write("Applied Filter: " + device.Filter.ToString() + " ");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error applying filter: {ex.Message}");
                    device.Close();
                    return;
                }
            }
            else
            {
                Console.WriteLine("⚠ No filter applied. Capturing all packets.");
            }
            Console.WriteLine($"Listening on {device.Description}...");

            // Capturing packets asynchronously
            device.OnPacketArrival += PacketHandler ;
            device.StartCapture();

            Console.WriteLine("Press Enter to stop capturing...");
            Console.ReadLine();

            device.StopCapture();
            device.Close();
        }

        private static void PacketHandler(object sender, SharpPcap.PacketCapture e )
        {
            var rawPacket = e.GetPacket();
            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            var ipPacket = packet.Extract<IPPacket>();
            if (ipPacket != null)
            {
                Console.WriteLine($"Captured Packet: {ipPacket.SourceAddress} ->{ipPacket.Protocol} -->{ipPacket.DestinationAddress}" );
            }
        }
    }
}
