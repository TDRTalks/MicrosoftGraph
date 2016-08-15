using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace GraphTester
{
    class Program
    {
        static void Main(string[] args)
        {
            AppSetup();
            Console.ReadKey();
        }

        public static async void AppSetup()
        {
            var clientId = "be91c60f-d263-4b44-9e14-4d5f03156a0f";
            var redirectUri = "urn:ietf:wg:oauth:2.0:oob";
            string[] scopes = {"Mail.Read"};

            PublicClientApplication pca = new PublicClientApplication(clientId);
            AuthenticationResult ar = await pca.AcquireTokenAsync(scopes);

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me/messages");

            message.Headers.Authorization = new AuthenticationHeaderValue("bearer", ar.Token);
            HttpResponseMessage response = await client.SendAsync(message);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
