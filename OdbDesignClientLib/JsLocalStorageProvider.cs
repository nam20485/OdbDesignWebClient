using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Odb.Client.Lib
{
    public class JsLocalStorageProvider : ILocalStorage
    {
        private readonly IJSRuntime _jSRuntime;

        public JsLocalStorageProvider(IJSRuntime jsRuntime)
        {
            _jSRuntime = jsRuntime;
        }

        public async ValueTask ClearAsync()
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.clear");
        }

        public async ValueTask<string> GetItemAsync(string key)
        {
            return await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async ValueTask<string> KeyAsync(int index)
        {
            return await _jSRuntime.InvokeAsync<string>("localStorage.key", index);
        }

        public async ValueTask RemoveItemAsync(string key)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public ValueTask SetItemAsync(string key, string value)
        {
            return _jSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }
    }    
}
