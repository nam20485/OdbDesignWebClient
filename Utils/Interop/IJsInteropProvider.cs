using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Interop
{
    public interface IJsInteropProvider
    {
        ValueTask<TReturn> InvokeAsync<TReturn>(string name, params object[] @params);
        ValueTask InvokeVoidAsync(string name, params object[] @params);
        TReturn Invoke<TReturn>(string name, params object[] @params);
        void InvokeVoid(string name, params object[] @params);
    }
}
