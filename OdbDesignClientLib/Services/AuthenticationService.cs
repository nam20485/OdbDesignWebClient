using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Odb.Client.Lib.Services
{
    public class AuthenticationService : IAuthenticationService
    {            
        public string Username { get; }

        private AuthenticationHeaderValue _authenticationHeaderValue;
        private readonly ILocalStorageService _localStorageService;

        public AuthenticationService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public AuthenticationHeaderValue GetAuthenticationHeaderValue()
        {
            return _authenticationHeaderValue;
        }

        public bool IsLoggedIn()
        {
            return _authenticationHeaderValue != null;
        }

        public void Login(string username, string pass)
        {
            var authHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{pass}"));
            _authenticationHeaderValue = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public void Logout()
        {
            _authenticationHeaderValue = null;
        }
    }
}
