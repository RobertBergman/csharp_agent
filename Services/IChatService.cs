using Agent.Models;

namespace Agent.Services;

public interface IChatService
{
    Task<string> SendMessageAsync(string message);
    Task<T> GetStructuredResponseAsync<T>(string message) where T : class;
    Task<string> SendMessageWithAttachmentsAsync(string message, List<UriAttachment> attachments);
}