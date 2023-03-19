Console.WriteLine("Hello, World!");
var client = new ServiceReference1.ServiceClient();
client.ClientCredentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
Console.WriteLine(await client.GetDataAsync(12));

