using Agent.Models;

namespace Agent.Services;

public class SearchService : ISearchService
{
    private readonly IDocumentIngestionService _ingestionService;

    public SearchService(IDocumentIngestionService ingestionService)
    {
        _ingestionService = ingestionService;
    }

    public async IAsyncEnumerable<Document> SearchAsync(string query, int top = 5)
    {
        await Task.Delay(1); // Make async
        
        var documents = _ingestionService.GetAllDocuments();
        var queryLower = query.ToLowerInvariant();
        
        var matchingDocuments = documents
            .Where(d => d.Text.ToLowerInvariant().Contains(queryLower))
            .Take(top);

        foreach (var document in matchingDocuments)
        {
            yield return document;
        }
    }
}