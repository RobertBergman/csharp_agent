using Agent.Models;

namespace Agent.Services;

public interface IStructuredExtractionService
{
    Task<List<ReceiptData>> ExtractReceiptsAsync(string message, List<UriAttachment>? attachments = null);
    Task<List<TripOption>> GenerateTripOptionsAsync(string requirements);
}