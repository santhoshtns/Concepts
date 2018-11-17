using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace ConceptTests
{
    public class PdfGenerator
    {
        public string Url { get; set; }

        public string BaseUrl { get; set; }

        public string Token { get; set; }

        public PdfGenerator()
        {
            Url = "https://doc-generater-dev.azurewebsites.net/api/DocumentGenerator/DownloadByteData";
            Token = "c3dFR2RRbnRYNVNZV0Y0VzpWd1F4VlBacTMyWUM5WUwy";
        }

        public void Generate(string html)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(Url);

                var values = new Dictionary<string, string>();
                values.Add("html", html);
                values.Add("baseUrl", BaseUrl);
                var jsonStr = JsonConvert.SerializeObject(values);
                var stringContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                var authenticationToken = "Basic " + Token;
                var response = PostRequest(client, Url, stringContent,
                    "Authorization", authenticationToken, "application/json");

                var curbyteArray = response.Content.ReadAsByteArrayAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot convert html to pdf.");
                }

                using (Stream output = File.OpenWrite("c:\\file.pdf"))
                {
                    output.Write(curbyteArray, 0, curbyteArray.Length);
                }
            }
        }

        public static HttpResponseMessage PostRequest(HttpClient client, string apiURL, StringContent stringContent, string tokenName = "", string tokenValue = "", string contentType = "")
        {
            if (!string.IsNullOrEmpty(contentType)) client.DefaultRequestHeaders.Add("Accept", contentType);
            if (!string.IsNullOrEmpty(tokenName)) client.DefaultRequestHeaders.Add(tokenName, tokenValue);
            return client.PostAsync(apiURL, stringContent).Result;
        }
    }
}
