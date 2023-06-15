using GithubAntiCorruption.Application.Services;
using GithubAntiCorruption.Application.Services.CreateRepository;
using GithubAntiCorruption.Application.Services.Webhook.CreateWebhook;
using Microsoft.AspNetCore.Mvc;

namespace GithubAntiCorruption.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RepositoryController : ControllerBase
{
    private readonly ILogger<RepositoryController> _logger;
    private readonly IGitHubClient _gitHubClient;

    public RepositoryController(ILogger<RepositoryController> logger, IGitHubClient gitHubClient)
    {
        _logger = logger;
        _gitHubClient = gitHubClient;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRepositoryAsync(CreateRepositoryDto createRepositoryDto) 
    {

        var response = await _gitHubClient.CreateRepositoryAsync(createRepositoryDto);
        return Ok(response);
    }

    [HttpGet("branche/{owner}/{repo}")]
    public async Task<IActionResult> GetBranchesAsync(string owner, string repo)
    {
        var response = await _gitHubClient.ListBranchesRepository(owner, repo);
        return Ok(response);
    }

    [HttpGet("webhook/{owner}/{repo}")]
    public async Task<IActionResult> GetWebhooksAsync(string owner, string repo)
    {
        var response = await _gitHubClient.ListListWebhooksRepository(owner, repo);
        return Ok(response);
    }

    [HttpPost("webhook/{owner}/{repo}")]
    public async Task<IActionResult> AddWebhooksAsync(string owner, string repo, CreateWebhookDto createWebhookDto)
    {
        var response = await _gitHubClient.CreateWebhookRepository(owner, repo, createWebhookDto);
        return Ok(response);
    }

    [HttpPut("webhook")]
    public async Task<IActionResult> UpdateWebhooksAsync()
    {

        return Ok();
    }
}
