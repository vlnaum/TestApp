using System.Text.Json.Serialization;

namespace TestApp.Api.AppCenter.Models;

public class Branch
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}