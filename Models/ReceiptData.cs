namespace Agent.Models;

public record ReceiptData
{
    public string Id { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public string Category { get; init; } = string.Empty;
    public DateTime? Date { get; init; }
    public string ImageUrl { get; init; } = string.Empty;

    public ReceiptData WithCategory(string newCategory)
    {
        return this with { Category = newCategory };
    }

    public ReceiptData WithDecimalAmount(decimal newAmount)
    {
        return this with { Amount = newAmount };
    }
}