using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odb.Client.Lib.Interop
{
    public interface ILocalStorageProvider
    {
        ValueTask SetItemAsync(string key, string value);
        ValueTask<string> GetItemAsync(string key);
        ValueTask RemoveItemAsync(string key);
        ValueTask ClearAsync();
        ValueTask<string> KeyAsync(int index);
        ValueTask<int> LengthAsync();

        void SetItem(string key, string value);
        string GetItem(string key);
        void RemoveItem(string key);
        void Clear();
        string Key(int index);
        int Length();
    }
}
