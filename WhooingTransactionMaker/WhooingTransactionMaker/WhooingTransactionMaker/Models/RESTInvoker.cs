using Newtonsoft.Json;
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
using WhooingTransactionMaker.DataModels;
using WhooingTransactionMaker.Helpers;

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
        private static readonly Lazy<HttpClient> httpClient = new Lazy<HttpClient>(() => new HttpClient()
        {
            BaseAddress = new Uri(Whooing.BaseUrl),
        });

        private static bool isXAPIAdded;

        private static HttpClient Client { get { return httpClient.Value; } }


        private static void SetXAPIKey()
        {
            if (isXAPIAdded ||
                Whooing.Instance.XAPIKey == null)
            {
                return;
            }

            isXAPIAdded = true;
            Client.DefaultRequestHeaders.TryAddWithoutValidation("X-API-KEY", Whooing.Instance.XAPIKey);
        }

        public static async Task<JObject> Invoke(RestMethod method, string uri)
        {
            SetXAPIKey();

            switch (method)
            {
                case RestMethod.GET:
                    string content = await InvokeGet(uri);
                    return JObject.Parse(content);
            }

            return null;
        }

        public static async Task<InvokeResult<T>> Invoke<T>(RestMethod method, string uri, string data)
        {
            SetXAPIKey();

            switch (method)
            {
                case RestMethod.GET:
                    string content = await InvokeGet(uri);
                    InvokeResult<T> res = null;
                    try
                    {
                        res = JsonConvert.DeserializeObject<InvokeResult<T>>(content);
                        return res;
                    }
                    catch (Exception e)
                    {
                        SubsystemUtils.Instance.Err("Json deserialization is failed, " + e.Message);
                        SubsystemUtils.Instance.Err("------------------------------------------------------------------");
                        SubsystemUtils.Instance.Err(content);
                        SubsystemUtils.Instance.Err("------------------------------------------------------------------");
                        res = null;
                    }
                    return res;
            }

            return null;
        }

        private static async Task<string> InvokeGet(string path)
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync(path);
                if (response.IsSuccessStatusCode == false)
                {
                    SubsystemUtils.Instance.Err("Error response, " + response.StatusCode);
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(content))
                {
                    SubsystemUtils.Instance.Err("Response contained empty body...");
                    return null;
                }

                SubsystemUtils.Instance.Dbg($"Response Body: \r\n {content}");

                // TODO : check error code of whooing.
                return content;
            }
            catch (Exception e)
            {
                SubsystemUtils.Instance.Err($"RestInvoker - Error occured, {e.Message}");
            }

            return null;
        }

        private static async Task<string> InvokePost(string path, string data)
        {
            var response = await Client.PostAsync(path, new ByteArrayContent(Encoding.UTF8.GetBytes(data)));
            return await response.Content.ReadAsStringAsync();
        }

    }
}
