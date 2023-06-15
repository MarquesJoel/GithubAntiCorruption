using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GithubAntiCorruption.Application.Services.WebhookRepository
{
    public class Config
    {
        [JsonPropertyName("content_type")]
        public string ContentType { get; init; }
        [JsonPropertyName("insecure_ssl")]
        public string InsecureSsl { get; init; }
        public string Url { get; init; }
    }
}
