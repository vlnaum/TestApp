using System.Text.Json.Serialization;

namespace TestApp.Api.AppCenter.Models;

public class Build
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("buildNumber")]
    public string BuildNumber { get; set; }

    [JsonPropertyName("queueTime")]
    public DateTime QueueTime { get; set; }

    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("finishTime")]
    public DateTime FinishTime { get; set; }

    [JsonPropertyName("lastChangedDate")]
    public DateTime LastChangedDate { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("result")]
    public string Result { get; set; }

    [JsonPropertyName("sourceBranch")]
    public string SourceBranch { get; set; }

    [JsonPropertyName("sourceVersion")]
    public string SourceVersion { get; set; }
}