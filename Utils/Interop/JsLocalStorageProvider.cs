using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Utils.Interop
{
    public class JsLocalStorageProvider : ILocalStorageProvider
    {
        private readonly IJsInteropProvider _jsInteropProvider;

        private const string LOCALSTORAGE_CLEAR_METHOD = "localStorage.clear";
        private const string LOCALSTORAGE_GETITEM_METHOD = "localStorage.getItem";
        private const string LOCALSTORAGE_KEY_METHOD = "localStorage.key";
        private const string LOCALSTORAGE_LENGTH_METHOD = "localStorage.length";
        private const string LOCALSTORAGE_REMOVEITEM_METHOD = "localStorage.removeItem";
        private const string LOCALSTORAGE_SETITEM_METHOD = "localStorage.setItem";

        public JsLocalStorageProvider(IJsInteropProvider jsInteropProvider)
        {
            _jsInteropProvider = jsInteropProvider;
        }

        public void Clear()
        {
            _jsInteropProvider.InvokeVoid(LOCALSTORAGE_CLEAR_METHOD);
        }

        public async ValueTask ClearAsync()
        {
            await _jsInteropProvider.InvokeVoidAsync(LOCALSTORAGE_CLEAR_METHOD);
        }

        public string GetItem(string key)
        {
            return _jsInteropProvider.Invoke<string>(LOCALSTORAGE_GETITEM_METHOD, key);
        }

        public async ValueTask<string> GetItemAsync(string key)
        {
            return await _jsInteropProvider.InvokeAsync<string>(LOCALSTORAGE_GETITEM_METHOD, key);
        }

        public string Key(int index)
        {
            return _jsInteropProvider.Invoke<string>(LOCALSTORAGE_KEY_METHOD, index);
        }

        public async ValueTask<string> KeyAsync(int index)
        {
            return await _jsInteropProvider.InvokeAsync<string>(LOCALSTORAGE_KEY_METHOD, index);
        }

        public int Length()
        {
            return _jsInteropProvider.Invoke<int>(LOCALSTORAGE_LENGTH_METHOD);
        }

        public async ValueTask<int> LengthAsync()
        {
            return await _jsInteropProvider.InvokeAsync<int>(LOCALSTORAGE_LENGTH_METHOD);
        }

        public void RemoveItem(string key)
        {
            _jsInteropProvider.InvokeVoid(LOCALSTORAGE_REMOVEITEM_METHOD, key);
        }

        public async ValueTask RemoveItemAsync(string key)
        {
            await _jsInteropProvider.InvokeVoidAsync(LOCALSTORAGE_REMOVEITEM_METHOD, key);
        }

        public void SetItem(string key, string value)
        {
            _jsInteropProvider.InvokeVoid(LOCALSTORAGE_SETITEM_METHOD, key, value);
        }

        public ValueTask SetItemAsync(string key, string value)
        {
            return _jsInteropProvider.InvokeVoidAsync(LOCALSTORAGE_SETITEM_METHOD, key, value);
        }
    }
}
