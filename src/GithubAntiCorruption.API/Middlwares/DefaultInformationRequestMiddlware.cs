using GithubAntiCorruption.Application.DefaultInformations;
using System.Net;

namespace GithubAntiCorruption.API.Middlwares
{
    public class DefaultInformationRequestMiddlware
    {
        private readonly RequestDelegate _next;

        public DefaultInformationRequestMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, DefaultInformationsRequest defaultInformationsRequest)
        {
            defaultInformationsRequest.GitHubHeader = context.Request.Headers["x-github-token"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(defaultInformationsRequest.GitHubHeader))
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new
                {
                    context.Response.StatusCode,
                    Message = "Not found value from header x-github-token"
                });

                return;
            }

            await _next(context);

        }
    }
}
