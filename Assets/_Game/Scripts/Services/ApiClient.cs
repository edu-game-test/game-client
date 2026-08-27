using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Services
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

        public static async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await _http.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public static async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest body)
        {
            var response = await _http.PostAsJsonAsync(endpoint, body);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }
    }
}
