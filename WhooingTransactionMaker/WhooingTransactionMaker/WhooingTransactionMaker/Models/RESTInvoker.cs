using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.Models
{
    public enum RestMethod
    {
        POST,
        GET,
        PUT,
        DELETE,
    }
    public class RESTInvoker
    {
        private static readonly Lazy<HttpClient> httpClient = new Lazy<HttpClient>(() => new HttpClient());

        private static HttpClient Client { get { return httpClient.Value; } }

        public static async Task<JObject> Invoke(RestMethod method, string uri, string data)
        {
            switch (method)
            {
                case RestMethod.GET:
                    return await InvokeGet(uri);
            }

            return null;
        }

        private static async Task<JObject> InvokeGet(string uri)
        {
            JObject result = null;

            try
            {
                HttpResponseMessage response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode == false)
                {
                    return result;
                }
                var content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(content))
                {
                    Debug.WriteLine("Response contained empty body...");
                    return result;
                }

                result = JObject.Parse(content);
                Debug.WriteLine($"Response Body: \r\n {content}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error occured, {e.Message}");
                result = null;
                return result;
            }

            return result;
        }

        private static async Task<string> InvokePost(string uri, string data)
        {
            var response = await Client.PostAsync(uri, new ByteArrayContent(Encoding.UTF8.GetBytes(data)));
            return await response.Content.ReadAsStringAsync();
        }

    }
}
