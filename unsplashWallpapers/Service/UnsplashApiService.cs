using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using unsplashWallpapers.Dto;

namespace unsplashWallpapers.Service
{
    internal class UnsplashApiService
    {
        private HttpClient client;

        public UnsplashApiService (string apiKey)
        {
            if (apiKey.Length <= 5)
            {
                throw new ArgumentException("Не верный токен");
            }

            this.client = new HttpClient ();
            this.client.BaseAddress = new Uri("https://api.unsplash.com");
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", apiKey);
        }

        public ImageDto getNewImage(string[] tags)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "orientation", "landscape" },
                { "query", string.Join(",", tags)}
            };
            var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
            var queryString = dictFormUrlEncoded.ReadAsStringAsync();
            var request = new HttpRequestMessage(HttpMethod.Get, "/photos/random?" + queryString);

            Task<string> task = sendRequest(request).Content.ReadAsStringAsync();

            var jsonResult = string.Empty;

            Task continuation = task.ContinueWith(t => {
                jsonResult = t.Result;
            });
            continuation.Wait();

            JObject response = JObject.Parse(jsonResult);

            return new ImageDto(response.SelectToken("$.id").ToString(), response.SelectToken("$.links.download").ToString());
        }

        private HttpResponseMessage sendRequest(HttpRequestMessage requset)
        {
            var response = this.client.Send(requset);

            return response;
        }
    }
}
