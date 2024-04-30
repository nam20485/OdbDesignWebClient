using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Odb.Client.Lib.Services
{
    public class AuthenticationService : IAuthenticationService
    {            
        public string Username { get; }

        private readonly ILocalStorageService _localStorageService;

        public AuthenticationService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderValueAsync()
        {
            var username = await _localStorageService.GetUsernameAsync();
            var password = await _localStorageService.GetPasswordAsync();

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var authHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                return new AuthenticationHeaderValue("Basic", authHeaderValue);
            }

            return null;
        }

        public async Task<bool> IsLoggedInAsync()
        {
            return await GetAuthenticationHeaderValueAsync() != null;
        }

        public async Task LoginAsync(string username, string pass)
        {
            await _localStorageService.SetUsernameAsync(username);
            await _localStorageService.SetPasswordAsync(pass);
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveAuthDataAsync();
        }
    }
}
