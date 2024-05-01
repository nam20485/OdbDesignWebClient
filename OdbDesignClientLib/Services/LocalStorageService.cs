using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.JSInterop;
using Odb.Client.Lib.Interop;

namespace Odb.Client.Lib.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private const string PasswordKey = "odbdwc_password";
        private const string UsernameKey = "odbdwc_username";
        
        private readonly ILocalStorageProvider _localStorage;

        public LocalStorageService(ILocalStorageProvider localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<string> GetPasswordAsync()
        {
            return await _localStorage.GetItemAsync(PasswordKey);
        }

        public async Task<string> GetUsernameAsync()
        {
            return await _localStorage.GetItemAsync(UsernameKey);
        }

        public async Task RemoveAuthDataAsync()
        {
            await _localStorage.RemoveItemAsync(UsernameKey);
            await _localStorage.RemoveItemAsync(PasswordKey);            
        }

        public async Task SetPasswordAsync(string password)
        {
            await _localStorage.SetItemAsync(PasswordKey, password);
        }

        public async Task SetUsernameAsync(string username)
        {
            await _localStorage.SetItemAsync(UsernameKey, username);
        }
    }
}
