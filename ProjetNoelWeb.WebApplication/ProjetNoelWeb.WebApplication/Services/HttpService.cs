﻿using Newtonsoft.Json;
using ProjetNoelWeb.WebApplication.Services.Interfaces;
using System.Net.Http.Headers;

namespace ProjetNoelWeb.WebApplication.Services
{
    public class HttpService : IHttpService
    {
        public async Task<T> SendHttpRequest<T>(string url, HttpMethod httpMethod, object? body = null, string? bearer = null)
        {
            try
            {
                var httpClient = new HttpClient();

                // For OAuth2.0
                if (!string.IsNullOrEmpty(bearer))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);

                var httpRequestMessage = new HttpRequestMessage() { Method = httpMethod, RequestUri = new Uri(url) };

                if (body != null)
                    httpRequestMessage.Content = JsonContent.Create(body);

                var response = httpClient.SendAsync(httpRequestMessage);

                if (response.Result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(await response.Result.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return default(T);
        }
    }
}
