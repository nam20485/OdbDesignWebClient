using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Interop;


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

        public string GetPassword()
        {
            return _localStorage.GetItem(PasswordKey);
        }

        public async Task<string> GetPasswordAsync()
        {
            return await _localStorage.GetItemAsync(PasswordKey);
        }

        public string GetUsername()
        {
           return _localStorage.GetItem(UsernameKey);
        }

        public async Task<string> GetUsernameAsync()
        {
            return await _localStorage.GetItemAsync(UsernameKey);
        }

        public void RemoveAuthData()
        {
            _localStorage.RemoveItem(UsernameKey);
            _localStorage.RemoveItem(PasswordKey);
        }

        public async Task RemoveAuthDataAsync()
        {
            await _localStorage.RemoveItemAsync(UsernameKey);
            await _localStorage.RemoveItemAsync(PasswordKey);            
        }

        public void SetPassword(string password)
        {
           _localStorage.SetItem(PasswordKey, password);
        }

        public async Task SetPasswordAsync(string password)
        {
            await _localStorage.SetItemAsync(PasswordKey, password);
        }

        public void SetUsername(string username)
        {
            _localStorage.SetItem(UsernameKey, username);
        }

        public async Task SetUsernameAsync(string username)
        {
            await _localStorage.SetItemAsync(UsernameKey, username);
        }
    }
}
