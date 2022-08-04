using System.Text.Json.Serialization;

namespace TestApp.Api.AppCenter.Models;

public class Branches
{
    [JsonPropertyName("branch")]
    public Branch Branch { get; set; }
}
