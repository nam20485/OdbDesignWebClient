using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Odb.Client.Lib
{
    public class LibJsonSerializerOptions
    {
        private static readonly JsonSerializerOptions _instance = new ()
        {
            AllowTrailingCommas = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: true)
            },
            ReferenceHandler = ReferenceHandler.Preserve,            
        };

        public static JsonSerializerOptions Instance => _instance;
    }
}
