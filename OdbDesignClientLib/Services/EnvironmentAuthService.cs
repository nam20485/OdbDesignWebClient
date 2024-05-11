using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Utils;

namespace Odb.Client.Lib.Services
{
    public class EnvironmentAuthService : IAuthenticationService
    {
        private const string ODBDESIGN_SERVER_REQUEST_USERNAME = "ODBDESIGN_SERVER_REQUEST_USERNAME";
        private const string ODBDESIGN_SERVER_REQUEST_PASSWORD = "ODBDESIGN_SERVER_REQUEST_PASSWORD";

        private string _username;
        private string _password;

        public EnvironmentAuthService()
        {
            var username = Environment.GetEnvironmentVariable(ODBDESIGN_SERVER_REQUEST_USERNAME);
            var password = Environment.GetEnvironmentVariable(ODBDESIGN_SERVER_REQUEST_PASSWORD);
            Login(username, password);
        }

        public AuthenticationHeaderValue GetAuthenticationHeaderValue()
        {
            var username = GetUsername();
            var password = GetPassword();
            return AuthUtils.MakeAuthHeaderValue(username, password);
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderValueAsync()
        {
            return await Task.Run(() => GetAuthenticationHeaderValue());
        }

        public string GetPassword()
        {
            return _password;
        }

        public async Task<string> GetPasswordAsync()
        {
            return await Task.Run(() => GetPassword());
        }

        public string GetUsername()
        {
            return _username;
        }

        public async Task<string> GetUsernameAsync()
        {
            return await Task.Run(() => GetUsername());
        }

        public bool IsLoggedIn()
        {
            return GetAuthenticationHeaderValue() != null;
        }

        public async Task<bool> IsLoggedInAsync()
        {
            return await Task.Run(() => IsLoggedIn());
        }

        public void Login(string username, string pass)
        {
            _username = username;
            _password = pass;
        }

        public async Task LoginAsync(string username, string pass)
        {
            await Task.Run(() => Login(username, pass));
        }

        public void Logout()
        {
            _username = null;
            _password = null;
        }

        public async Task LogoutAsync()
        {
            await Task.Run(() => Logout());
        }
    }
}
