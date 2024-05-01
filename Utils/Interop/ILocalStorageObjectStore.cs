using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Interop
{
    public interface ILocalStorageObjectStore
    {
        T GetItem<T>(string key);
        ValueTask<T> GetItemAsync<T>(string key);
        void RemoveItem(string key);
        ValueTask RemoveItemAsync(string key);
        void SetItem<T>(string key, T value);
        ValueTask SetItemAsync<T>(string key, T value);
        void Clear();
        ValueTask ClearAsync();
    }
}
