using Agent.Models;
using Agent.Services;

namespace Agent.Agents;

public class AgentOrchestrator : IAgentOrchestrator
{
    private readonly IChatService _chatService;
    private readonly IStructuredExtractionService _extractionService;
    private readonly ISearchService _searchService;

    public AgentOrchestrator(
        IChatService chatService,
        IStructuredExtractionService extractionService,
        ISearchService searchService)
    {
        _chatService = chatService;
        _extractionService = extractionService;
        _searchService = searchService;
    }

    public async Task<string> ProcessMessageAsync(string message, List<UriAttachment>? attachments = null)
    {
        if (attachments?.Any() == true)
        {
            return await _chatService.SendMessageWithAttachmentsAsync(message, attachments);
        }
        else
        {
            return await _chatService.SendMessageAsync(message);
        }
    }

    public async Task<List<ReceiptData>> ProcessReceiptsAsync(string message, List<UriAttachment>? attachments = null)
    {
        return await _extractionService.ExtractReceiptsAsync(message, attachments);
    }

    public async Task<List<TripOption>> PlanTripAsync(string requirements)
    {
        return await _extractionService.GenerateTripOptionsAsync(requirements);
    }

    public async Task<List<Document>> SearchDocumentsAsync(string query, int maxResults = 5)
    {
        var results = new List<Document>();
        await foreach (var document in _searchService.SearchAsync(query, maxResults))
        {
            results.Add(document);
        }
        return results;
    }
}