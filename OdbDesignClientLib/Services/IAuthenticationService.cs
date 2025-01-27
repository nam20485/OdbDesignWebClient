﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Odb.Client.Lib.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsLoggedInAsync();
        Task LoginAsync(string username, string pass);
        Task LogoutAsync();
        Task<AuthenticationHeaderValue> GetAuthenticationHeaderValueAsync();

        Task<string> GetUsernameAsync();
        Task<string> GetPasswordAsync();

        bool IsLoggedIn();
        void Login(string username, string pass);
        void Logout();
        AuthenticationHeaderValue GetAuthenticationHeaderValue();

        string GetUsername();
        string GetPassword();
    }
}
