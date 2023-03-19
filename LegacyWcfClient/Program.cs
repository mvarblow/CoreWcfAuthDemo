using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyWcfClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.ServiceClient();
            client.ClientCredentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
            Console.WriteLine(client.GetData(12));
        }
    }
}
