using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Ait.WeatherServer.Core.Helpers
{
    public class IPv4Helper
    {

        public static List<string> GetActiveIP4s()
        {
            List<string> activeIps = new List<string>();
            activeIps.Add("127.0.0.1");

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties iPInterfaceProperties = networkInterface.GetIPProperties();
                IPv4InterfaceProperties iPv4Properties = iPInterfaceProperties.GetIPv4Properties();
                int gwCounter = 0;
                foreach (GatewayIPAddressInformation gwadres in iPInterfaceProperties.GatewayAddresses)
                {
                    gwCounter++;
                }
                if (gwCounter > 0)
                {
                    foreach (UnicastIPAddressInformation ip in iPInterfaceProperties.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            activeIps.Add(ip.Address.ToString());

                        }
                    }
                }
            }



            // hier wordt een LIST gemaakt met alle IP nummers van 
            // je eigen actieve NICs
            // manueel wordt het loopback adres toegevoegd




            //List<string> activeIps = new List<string>();
            //activeIps.Add("127.0.0.1");
            //var host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        // last minute addition to code

            //        activeIps.Add(ip.ToString());
            //    }
            //}
            return activeIps;
        }
        public static bool PortInUse(int port)
        {
            // Ter info
            // Deze methode gebruiken we niet in deze app maar eigenlijk kan je best even nakijken
            // of de poort(en) die je in je eigen app gaat gebruiken ondertussen al niet door een
            // ander proces in gebruik is ...
            bool inUse = false;
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }
    }
}
