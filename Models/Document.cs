namespace Agent.Models;

public class Document
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public int PageNumber { get; set; }
    public string Text { get; set; } = string.Empty;
    public ReadOnlyMemory<float> Embedding { get; set; }
}