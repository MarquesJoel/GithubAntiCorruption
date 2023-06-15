using GithubAntiCorruption.Application.Services.WebhookRepository;

namespace GithubAntiCorruption.Application.Services.Webhook
{
    public class UpdateWebhookDto
    {
        public bool Active { get; set; }
        public List<string> Events { get; set; }
        public Config Config { get; set; }
    }
}
