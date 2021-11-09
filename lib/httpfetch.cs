using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace HTTPFetch {

    /// <summary><c>FetchResponse</c> defines the properties of a response from a HTTPFetch request.</summary>
    public sealed class FetchResponse {    
        public String BodyAsString { get; set; } 
        public dynamic BodyAsObject { get; set; }
        public string url { get; set; }
        public string ContentType { get; set; }
        public int StatusCode { get; set; }
        public System.Net.Http.Headers.HttpResponseHeaders Headers { get; set; }
        public string Method { get; set; }
    }

    /// <summary><c>Fetch.Get</c> sends a HTTP GET request using the standard HTTP libraries included in .NET and Newtonsoft.Json.</summary>
    public class Fetch {
        static readonly HttpClient HtClient = new HttpClient();

        public static async Task<FetchResponse> Get<GType>(string url) {
            var response = await HtClient.GetAsync(url);

            FetchResponse responseProperties = new FetchResponse();
            Console.WriteLine(response.Headers.GetType().GetProperty("Content-Type"));
            responseProperties.url = url;
            responseProperties.ContentType = response.Content.Headers.ContentType.ToString();
            responseProperties.Headers = response.Headers;
            responseProperties.StatusCode = (int)response.StatusCode;
            responseProperties.Method = "GET";

            string rawResponse = await response.Content.ReadAsStringAsync();
            responseProperties.BodyAsString = (string)rawResponse;
            var token = Newtonsoft.Json.Linq.JToken.Parse(responseProperties.BodyAsString);

            if (responseProperties.ContentType.Contains("application/json")) {
                responseProperties.BodyAsObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GType>(token.ToString());
            } else {
                responseProperties.BodyAsObject = new Object();
            };

            return responseProperties;
        }
    }
}