using Agent.Models;

namespace Agent.Services;

public class StructuredExtractionService : IStructuredExtractionService
{
    private readonly IChatService _chatService;

    public StructuredExtractionService(IChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task<List<ReceiptData>> ExtractReceiptsAsync(string message, List<UriAttachment>? attachments = null)
    {
        var prompt = $"""
            Extract receipt information from the following input. Return a JSON array of receipt objects.
            Each receipt should include: Id, Description, Amount, Category, Date (if available), ImageUrl (if from image).
            
            Input: {message}
            
            Return only valid JSON array of ReceiptData objects.
            """;

        if (attachments?.Any() == true)
        {
            var response = await _chatService.SendMessageWithAttachmentsAsync(prompt, attachments);
            return await _chatService.GetStructuredResponseAsync<List<ReceiptData>>(
                $"Convert this response to ReceiptData objects: {response}");
        }
        else
        {
            return await _chatService.GetStructuredResponseAsync<List<ReceiptData>>(prompt);
        }
    }

    public async Task<List<TripOption>> GenerateTripOptionsAsync(string requirements)
    {
        var prompt = $"""
            Generate 3-5 trip options based on the following requirements: {requirements}
            
            Each trip option should include:
            - Destination details
            - Flight information (outbound and return)
            - Hotel recommendations
            - Car rental options (if needed)
            - Total pricing
            
            Consider factors like cost, convenience, and user preferences.
            Return a JSON array of TripOption objects.
            """;

        return await _chatService.GetStructuredResponseAsync<List<TripOption>>(prompt);
    }
}