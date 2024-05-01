using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Odb.Client.Lib.Interop
{
    public class LocalStorageObjectStore : ILocalStorageObjectStore
    {
        private readonly ILocalStorageProvider _localStorageProvider;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            //NumberHandling
            ReferenceHandler = ReferenceHandler.Preserve,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            //PreferredObjectCreationHandling = JsonObjectCreationHandlingAttribute
            //UnknownTypeHandling = JsonUnknownTypeHandling.
            //UnmappedMemberHandling = JsonUnmappedMemberHandling.
            IncludeFields = true,
        };

        public LocalStorageObjectStore(ILocalStorageProvider localStorageProvider)
        {
            _localStorageProvider = localStorageProvider;
        }

        public async ValueTask<T> GetItemAsync<T>(string key)
        {
            var json = await _localStorageProvider.GetItemAsync(key);
            return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
        }

        public T GetItem<T>(string key)
        {
            var json = _localStorageProvider.GetItem(key);
            return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
        }

        public async ValueTask RemoveItemAsync(string key)
        {
            await _localStorageProvider.RemoveItemAsync(key);
        }

        public void RemoveItem(string key)
        {
            _localStorageProvider.RemoveItem(key);
        }

        public async ValueTask SetItemAsync<T>(string key, T value)
        {
            var json = JsonSerializer.Serialize(value, _jsonSerializerOptions);
            await _localStorageProvider.SetItemAsync(key, json);
        }

        public void SetItem<T>(string key, T value)
        {
            var json = JsonSerializer.Serialize(value, _jsonSerializerOptions);
            _localStorageProvider.SetItem(key, json);
        }

        public void Clear()
        {
            _localStorageProvider.Clear();
        }

        public async ValueTask ClearAsync()
        {
            await _localStorageProvider.ClearAsync();
        }
    }
}
