using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Odb.Client.Lib.Interop
{
    public class JsInteropProvider : IJsInteropProvider
    {
        //private readonly IJSRuntime _jsRuntime;
        private readonly IJSInProcessRuntime _jsInProcessRuntime;

        public JsInteropProvider(IJSRuntime jsRuntime)
        {
            //_jsRuntime = jsRuntime;
            _jsInProcessRuntime = jsRuntime as IJSInProcessRuntime;
        }

        public TReturn Invoke<TReturn>(string name, params object[] @params)
        {
            return _jsInProcessRuntime.Invoke<TReturn>(name, @params);
        }

        public void InvokeVoid(string name, params object[] @params)
        {
            _jsInProcessRuntime.InvokeVoid(name, @params);
        }

        public async ValueTask<TReturn> InvokeAsync<TReturn>(string name, params object[] @params)
        {
            return await _jsInProcessRuntime.InvokeAsync<TReturn>(name, @params);
        } 
        
        public async ValueTask InvokeVoidAsync(string name, params object[] @params)
        {
            await _jsInProcessRuntime.InvokeVoidAsync(name, @params);
        }
    }
}
