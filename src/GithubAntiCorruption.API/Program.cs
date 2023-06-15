using GithubAntiCorruption.API.Handlers;
using GithubAntiCorruption.API.Middlwares;
using GithubAntiCorruption.API.SwaggerFilters;
using GithubAntiCorruption.Application.DefaultInformations;
using GithubAntiCorruption.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.OpenApi.Models;
using Refit;

namespace GithubAntiCorruption.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<DefaultInformationsRequest>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo { Title = "GitHub API", Version = "v1" });
            config.OperationFilter<SwaggerDefaultHeaders>();
        });
        builder.Services.AddTransient<GitHubRequestDelegatingHandler>();

        builder.Services.AddRefitClient<IGitHubClient>()
            .ConfigureHttpClient(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.github.com");
            })
            .AddHttpMessageHandler<GitHubRequestDelegatingHandler>();

        

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseMiddleware<DefaultInformationRequestMiddlware>();

        app.Run();
    }
}
