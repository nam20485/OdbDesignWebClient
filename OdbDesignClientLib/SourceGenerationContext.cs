using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Odb.Client.Lib.Model;

namespace Odb.Client.Lib
{
    //[JsonSourceGenerationOptions()]
    // Root types
    [JsonSerializable(typeof(FileArchive))]
    [JsonSerializable(typeof(Design))]
    [JsonSerializable(typeof(FileArchiveListResponse))]
    // Design types
    [JsonSerializable(typeof(Pin.StringDictionary), TypeInfoPropertyName = $"{nameof(Pin)}StringDictionary")]
    [JsonSerializable(typeof(Net.StringDictionary), TypeInfoPropertyName = $"{nameof(Net)}StringDictionary")]
    [JsonSerializable(typeof(Component.StringDictionary), TypeInfoPropertyName = $"{nameof(Component)}StringDictionary")]
    [JsonSerializable(typeof(Part.StringDictionary), TypeInfoPropertyName = $"{nameof(Part)}StringDictionary")]
    [JsonSerializable(typeof(Package.StringDictionary), TypeInfoPropertyName = $"{nameof(Package)}StringDictionary")]
    // FileArchive types
    [JsonSerializable(typeof(StepDirectory.StringDictionary), TypeInfoPropertyName = $"{nameof(StepDirectory)}StringDictionary")]
    [JsonSerializable(typeof(LayerDirectory.StringDictionary), TypeInfoPropertyName = $"{nameof(LayerDirectory)}StringDictionary")]
    [JsonSerializable(typeof(NetlistFile.StringDictionary), TypeInfoPropertyName = $"{nameof(NetlistFile)}StringDictionary")]
    [JsonSerializable(typeof(NetName.StringDictionary), TypeInfoPropertyName = $"{nameof(NetName)}StringDictionary")]
    [JsonSerializable(typeof(NetRecord.StringDictionary), TypeInfoPropertyName = $"{nameof(NetRecord)}StringDictionary")]
    [JsonSerializable(typeof(PackageRecord.StringDictionary), TypeInfoPropertyName = $"{nameof(PackageRecord)}StringDictionary")]
    [JsonSerializable(typeof(SymbolsDirectory.StringDictionary), TypeInfoPropertyName = $"{nameof(SymbolsDirectory)}StringDictionary")]
    [JsonSerializable(typeof(FeatureRecord.Type), TypeInfoPropertyName = $"{nameof(FeatureRecord)}Type")]
    [JsonSerializable(typeof(FeatureIdRecord.Type), TypeInfoPropertyName = $"{nameof(FeatureIdRecord)}Type")]
    [JsonSerializable(typeof(ContourPolygon.Type), TypeInfoPropertyName = $"{nameof(ContourPolygon)}Type")]
    [JsonSerializable(typeof(PolygonPart.Type), TypeInfoPropertyName = $"{nameof(PolygonPart)}Type")]
    [JsonSerializable(typeof(SubnetRecord.Type), TypeInfoPropertyName = $"{nameof(SubnetRecord)}Type")]
    [JsonSerializable(typeof(PinRecord.Type), TypeInfoPropertyName = $"{nameof(PinRecord)}Type")]
    [JsonSerializable(typeof(OutlineRecord.Type), TypeInfoPropertyName = $"{nameof(OutlineRecord)}Type")]
    [JsonSerializable(typeof(Layer.Type), TypeInfoPropertyName = $"{nameof(Layer)}Type")]    
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }
}
