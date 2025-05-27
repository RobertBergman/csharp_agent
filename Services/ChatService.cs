using OpenAI;
using OpenAI.Chat;
using Agent.Models;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Agent.Services;

public class ChatService : IChatService
{
    private readonly OpenAIClient _openAIClient;
    private readonly string _model;

    public ChatService(OpenAIClient openAIClient, IConfiguration configuration)
    {
        _openAIClient = openAIClient;
        _model = configuration["OpenAI:Model"] ?? "gpt-4o-mini";
    }

    public async Task<string> SendMessageAsync(string message)
    {
        var messages = new List<ChatMessage>
        {
            new UserChatMessage(message)
        };

        var response = await _openAIClient.GetChatClient(_model).CompleteChatAsync(messages);
        return response.Value.Content[0].Text;
    }

    public async Task<T> GetStructuredResponseAsync<T>(string message) where T : class
    {
        var structuredPrompt = $"{message}\n\nReturn only valid JSON that matches the {typeof(T).Name} structure.";
        var jsonResponse = await SendMessageAsync(structuredPrompt);
        
        try
        {
            return JsonSerializer.Deserialize<T>(jsonResponse) ?? throw new InvalidOperationException("Failed to deserialize response");
        }
        catch (JsonException)
        {
            throw new InvalidOperationException("Failed to get structured response - invalid JSON returned");
        }
    }

    public async Task<string> SendMessageWithAttachmentsAsync(string message, List<UriAttachment> attachments)
    {
        var messages = new List<ChatMessage>();
        
        if (attachments.Any(a => a.ContentType.StartsWith("image/")))
        {
            var content = new List<ChatMessageContentPart>
            {
                ChatMessageContentPart.CreateTextPart(message)
            };

            foreach (var attachment in attachments.Where(a => a.ContentType.StartsWith("image/")))
            {
                if (attachment.Uri.StartsWith("data:"))
                {
                    content.Add(ChatMessageContentPart.CreateImagePart(BinaryData.FromBytes(Convert.FromBase64String(attachment.Uri.Split(',')[1])), attachment.ContentType));
                }
                else if (File.Exists(attachment.Uri.Replace("file://", "")))
                {
                    var imageBytes = await File.ReadAllBytesAsync(attachment.Uri.Replace("file://", ""));
                    content.Add(ChatMessageContentPart.CreateImagePart(BinaryData.FromBytes(imageBytes), attachment.ContentType));
                }
            }

            messages.Add(new UserChatMessage(content));
        }
        else
        {
            messages.Add(new UserChatMessage(message));
        }

        var response = await _openAIClient.GetChatClient(_model).CompleteChatAsync(messages);
        return response.Value.Content[0].Text;
    }
}