using System.Text.Json.Serialization;

namespace GithubAntiCorruption.Application.Services.CreateRepository
{
    public class CreateRepositoryDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Homepage { get; init; }
        
        [JsonPropertyName("has_issues")]
        public bool has_issues { get; init; }
        
        [JsonPropertyName("has_projects")]
        public bool has_projects { get; init; }

        [JsonPropertyName("has_wiki")]
        public bool has_wiki { get; init; }
    }
}
