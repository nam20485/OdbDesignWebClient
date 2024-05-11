using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Utils;

namespace Odb.Client.Lib.Services
{
    public class LocalStorageAuthService : IAuthenticationService
    {            
        private readonly ILocalStorageService _localStorageService;

        public LocalStorageAuthService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderValueAsync()
        {
            var username = await GetUsernameAsync();
            var password = await GetPasswordAsync();
            return AuthUtils.MakeAuthHeaderValue(username, password);
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

        public async Task<string> GetUsernameAsync()
        {
            return await _localStorageService.GetUsernameAsync();
        }

        public async Task<string> GetPasswordAsync()
        {
            return await _localStorageService.GetPasswordAsync();
        }

        public bool IsLoggedIn()
        {
            return GetAuthenticationHeaderValue() != null;
        }

        public void Login(string username, string pass)
        {
            _localStorageService.SetUsername(username);
            _localStorageService.SetPassword(pass);
        }

        public void Logout()
        {
            _localStorageService.RemoveAuthData();
        }

        public AuthenticationHeaderValue GetAuthenticationHeaderValue()
        {
            var username = GetUsername();
            var password = GetPassword();
            return AuthUtils.MakeAuthHeaderValue(username, password);
        }

        public string GetUsername()
        {
            return _localStorageService.GetUsername();
        }

        public string GetPassword()
        {
            return _localStorageService.GetPassword();
        }
    }
}
