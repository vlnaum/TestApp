using System.Text.Json.Serialization;

namespace TestApp.Api.AppCenter.Models;

public class BuildRequestParams
{
    [JsonPropertyName("sourceVersion")]
    public string SourceVersion { get; set; }

    [JsonPropertyName("debug")]
    public bool Debug { get; set; }
}