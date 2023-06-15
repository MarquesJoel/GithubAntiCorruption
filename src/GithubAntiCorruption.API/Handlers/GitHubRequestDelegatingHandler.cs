using GithubAntiCorruption.Application.DefaultInformations;
using Refit;

namespace GithubAntiCorruption.API.Handlers
{
    public class GitHubRequestDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GitHubRequestDelegatingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var defaultInformations = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<DefaultInformationsRequest>();
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", defaultInformations.GitHubHeader);

            return await base.SendAsync(request, cancellationToken);

        }
    }
}
