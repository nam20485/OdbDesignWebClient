using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Odb.Client.Lib.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private const string PasswordKey = "password";
        private const string UsernameKey = "username";
        
        private readonly ILocalStorage _localStorage;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
           _localStorage = new JsLocalStorageProvider(jsRuntime);
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
