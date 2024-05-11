using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Utils
{
    public static class AuthUtils
    {
        private const string Scheme = "Basic";

        public static AuthenticationHeaderValue MakeAuthHeaderValue(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var authHeaderValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                //var authHeaderValue = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{password}"));
                return new AuthenticationHeaderValue(Scheme, authHeaderValue);
            }

            return null;
        }      
    }
}
