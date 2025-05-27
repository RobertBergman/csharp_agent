using Agent.Models;

namespace Agent.Services;

public interface IDocumentIngestionService
{
    Task IngestAsync(string sourceDirectory);
    Task IngestFileAsync(string filePath);
    List<Document> GetAllDocuments();
}