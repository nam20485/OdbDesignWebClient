using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Odb.Client.Lib.Services
{
    public interface IAuthenticationService
    {
        bool IsLoggedIn();
        void Login(string username, string pass);
        void Logout();
        AuthenticationHeaderValue GetAuthenticationHeaderValue();
    }
}
