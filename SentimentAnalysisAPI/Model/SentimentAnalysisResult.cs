public class SentimentAnalysisResult
{
    public int Id { get; set; }
    public string Analysis { get; set; }

    // Foreign key for one-to-one relationship
    public int SentimentId { get; set; }
    //public Sentiment Sentiment { get; set; }
}