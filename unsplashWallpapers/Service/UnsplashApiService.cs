using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
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
                { "query", string.Join(" or ", tags)}
            };
            var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
            var queryString = dictFormUrlEncoded.ReadAsStringAsync();
            var request = new HttpRequestMessage(HttpMethod.Get, "/photos/random?" + queryString.Result);

            Task<string> task = sendRequest(request).Content.ReadAsStringAsync();

            var jsonResult = string.Empty;

            Task continuation = task.ContinueWith(t => {
                jsonResult = t.Result;
            });
            continuation.Wait();

            JObject response = JObject.Parse(jsonResult);

            var ImageLocation = this.getImageLocation(response.SelectToken("$.links.download_location").ToString());


            return new ImageDto(response.SelectToken("$.id").ToString(), ImageLocation);
        }

        public async Task<ImageDto> DownloadImageAsync(ImageDto needDownloadImage, string downloadPath)
        {
            var res = await this.client.GetAsync(needDownloadImage.DownloadUri);

            if (!res.IsSuccessStatusCode) {
                throw new Exception("Не удалось скачать картинку");
            }

            byte[] bytes = await res.Content.ReadAsByteArrayAsync();
            Image image = Image.FromStream(new MemoryStream(bytes));
            var path = downloadPath + "/" + needDownloadImage.Id + ".jpg";
            image.Save(path);
            needDownloadImage.RealPath = path;

            return needDownloadImage;
        }

        private HttpResponseMessage sendRequest(HttpRequestMessage requset)
        {
            var response = this.client.Send(requset);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Не удалось выполнить запрос");
            }

            return response;
        }


        private string getImageLocation(string uri)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var res = this.client.Send(requestMessage);

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Не удалось скачать картинку");
            }

            Task<string> task = res.Content.ReadAsStringAsync();
            var jsonResult = string.Empty;

            Task continuation = task.ContinueWith(t => {
                jsonResult = t.Result;
            });
            continuation.Wait();

            JObject response = JObject.Parse(jsonResult);

            return (string)response.SelectToken("$.url");
        }
    }
}
