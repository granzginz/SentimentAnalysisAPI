using Microsoft.EntityFrameworkCore;

public class SentimentDbContext : DbContext
{
    public SentimentDbContext(DbContextOptions<SentimentDbContext> options) : base(options) { }

    public DbSet<Sentiment> Sentiments { get; set; }
    public DbSet<SentimentAnalysisResult> SentimentAnalysisResults { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<SentimentTag> SentimentTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
}
