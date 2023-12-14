public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Many-to-Many Relationship
    public List<SentimentTag> SentimentTags { get; set; }
}