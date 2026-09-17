using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MetaFramework.Unity.Core;
using Newtonsoft.Json;
using UnityEngine;

namespace MetaFramework.Unity.Net
{
    public static class ApiClient
    {
        private static readonly HttpClient _http = new()
        {
            BaseAddress = new System.Uri(GetServerUrl())
        };

        private static string GetServerUrl() =>
            Resources.Load<GameConfig>("GameConfig")?.ServerUrl ?? "http://localhost:5000";

        public static void SetAuthToken(string token)
        {
            _http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _http.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest body)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }
    }
}
