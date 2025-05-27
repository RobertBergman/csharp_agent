using Agent.Models;

namespace Agent.Agents;

public interface IAgentOrchestrator
{
    Task<string> ProcessMessageAsync(string message, List<UriAttachment>? attachments = null);
    Task<List<ReceiptData>> ProcessReceiptsAsync(string message, List<UriAttachment>? attachments = null);
    Task<List<TripOption>> PlanTripAsync(string requirements);
    Task<List<Document>> SearchDocumentsAsync(string query, int maxResults = 5);
}