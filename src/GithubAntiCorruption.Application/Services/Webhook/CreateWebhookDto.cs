using GithubAntiCorruption.Application.Services.WebhookRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubAntiCorruption.Application.Services.Webhook.CreateWebhook
{
    public class CreateWebhookDto
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<string> Events { get; set; }
        public Config Config { get; set; }
    }
}
