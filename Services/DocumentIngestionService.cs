using Agent.Models;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace Agent.Services;

public class DocumentIngestionService : IDocumentIngestionService
{
    private readonly List<Document> _documents = new();

    public async Task IngestAsync(string sourceDirectory)
    {
        var pdfFiles = Directory.GetFiles(sourceDirectory, "*.pdf");

        foreach (var filePath in pdfFiles)
        {
            await IngestFileAsync(filePath);
        }
    }

    public async Task IngestFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");

        await Task.Run(() =>
        {
            using var pdfReader = new PdfReader(filePath);
            using var pdfDocument = new PdfDocument(pdfReader);
            
            int documentId = _documents.Count;

            for (int pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
            {
                var page = pdfDocument.GetPage(pageNum);
                var strategy = new SimpleTextExtractionStrategy();
                var text = PdfTextExtractor.GetTextFromPage(page, strategy);
                
                if (string.IsNullOrWhiteSpace(text) || text.Length < 50)
                    continue;

                _documents.Add(new Document
                {
                    Id = documentId++,
                    FileName = Path.GetFileName(filePath),
                    PageNumber = pageNum,
                    Text = text.Trim(),
                    Embedding = ReadOnlyMemory<float>.Empty
                });
            }
        });
    }

    public List<Document> GetAllDocuments() => _documents;
}