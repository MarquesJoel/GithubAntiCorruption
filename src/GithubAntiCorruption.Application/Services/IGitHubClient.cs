using GithubAntiCorruption.Application.Services.CreateRepository;
using GithubAntiCorruption.Application.Services.GetBranchesRepository;
using GithubAntiCorruption.Application.Services.Webhook;
using GithubAntiCorruption.Application.Services.Webhook.CreateWebhook;
using GithubAntiCorruption.Application.Services.WebhookRepository;
using Refit;

namespace GithubAntiCorruption.Application.Services
{
    [Headers("User-Agent: GitHubTest")]
    public interface IGitHubClient
    {
        [Post("/user/repos")]
        Task<CreateRepositoryResponse> CreateRepositoryAsync(CreateRepositoryDto payload);

        [Get("/repos/{owner}/{repo}/branches")]
        Task<List<BrancheResponse>> ListBranchesRepository(string owner, string repo);

        [Get("/repos/{owner}/{repo}/hooks")]
        Task<List<WebhookResponse>> ListListWebhooksRepository(string owner, string repo);

        [Post("/repos/{owner}/{repo}/hooks")]
        Task<WebhookResponse> CreateWebhookRepository(string owner, string repo, [Body] CreateWebhookDto payload);

        [Patch("/repos/{owner}/{repo}/hooks/{id}")]
        Task<WebhookResponse> UpdateWebhookRepository(string owner, string repo, string id, [Body] UpdateWebhookDto payload);
    }
}
