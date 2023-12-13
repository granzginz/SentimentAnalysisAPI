// Sentiment.cs
public class Sentiment
{
    public int Id { get; set; }
    public string ImageDescription { get; set; }
    public int Reposts { get; set; }
    public int LoveCount { get; set; }

    // One-to-One Relationship
    public SentimentAnalysisResult AnalysisResult { get; set; }

    // One-to-Many Relationship
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    // Many-to-Many Relationship
    public List<SentimentTag> SentimentTags { get; set; }
}
