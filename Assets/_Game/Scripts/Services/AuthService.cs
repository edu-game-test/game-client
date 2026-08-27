using System.Threading.Tasks;
using UnityEngine;

namespace Game.Services
{
    public class AuthService
    {
        private const string TokenKey = "auth_token";

        public bool IsAuthenticated => !string.IsNullOrEmpty(PlayerPrefs.GetString(TokenKey));

        public string? GetToken() =>
            PlayerPrefs.HasKey(TokenKey) ? PlayerPrefs.GetString(TokenKey) : null;

        public async Task<bool> LoginAsync(string firebaseToken)
        {
            var result = await ApiClient.PostAsync<LoginRequest, LoginResponse>(
                "/auth/login",
                new LoginRequest { FirebaseToken = firebaseToken });

            if (result is null) return false;

            PlayerPrefs.SetString(TokenKey, result.AccessToken);
            PlayerPrefs.Save();
            ApiClient.SetAuthToken(result.AccessToken);
            return true;
        }

        public void Logout()
        {
            PlayerPrefs.DeleteKey(TokenKey);
        }

        private record LoginRequest { public string FirebaseToken { get; init; } = ""; }
        private record LoginResponse { public string AccessToken { get; init; } = ""; }
    }
}
