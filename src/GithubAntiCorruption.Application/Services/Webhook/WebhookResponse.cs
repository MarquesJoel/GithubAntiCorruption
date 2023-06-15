using System.Text.Json.Serialization;

namespace GithubAntiCorruption.Application.Services.WebhookRepository
{
    public class WebhookResponse
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<string> Events { get; set; }
        public Config Config { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        public string Url { get; set; }
        
        [JsonPropertyName("test_url")]
        public string TestUrl { get; set; }
        [JsonPropertyName("ping_url")]
        public string PingUrl { get; set; }
        [JsonPropertyName("deliveries_url")]
        public string DeliveriesUrl { get; set; }
        [JsonPropertyName("last_response")]
        public LastResponse LastResponse { get; set; }
    }
}
