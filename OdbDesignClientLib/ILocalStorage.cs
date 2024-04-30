using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odb.Client.Lib
{
    public interface ILocalStorage
    {
        ValueTask SetItemAsync(string key, string value);
        ValueTask<string> GetItemAsync(string key);
        ValueTask RemoveItemAsync(string key);
        ValueTask ClearAsync();
        ValueTask<string> KeyAsync(int index);
    }
}
