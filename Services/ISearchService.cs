using Agent.Models;

namespace Agent.Services;

public interface ISearchService
{
    IAsyncEnumerable<Document> SearchAsync(string query, int top = 5);
}