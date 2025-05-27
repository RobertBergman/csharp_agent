using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OpenAI;
using Agent.Services;
using Agent.Agents;

namespace Agent.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var openAiApiKey = configuration["OpenAI:ApiKey"] ?? throw new InvalidOperationException("OpenAI API key not configured");

        services.AddSingleton(new OpenAIClient(openAiApiKey));

        services.AddSingleton<IDocumentIngestionService, DocumentIngestionService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<IStructuredExtractionService, StructuredExtractionService>();
        services.AddScoped<IAgentOrchestrator, AgentOrchestrator>();

        return services;
    }
}