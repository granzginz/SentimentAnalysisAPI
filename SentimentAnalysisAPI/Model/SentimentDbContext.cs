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
        // Configure Sentiment and SentimentAnalysisResult relationship (1-1)
        modelBuilder.Entity<Sentiment>()
            .HasOne(s => s.SentimentAnalysisResult)
            .WithOne(sar => sar.Sentiment)
            .HasForeignKey<SentimentAnalysisResult>(sar => sar.SentimentId);

        // Configure Category and Sentiment relationship (1-n)
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Sentiments)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId);

        // Configure SentimentTag relationship (n-n)
        modelBuilder.Entity<SentimentTag>()
            .HasKey(st => new { st.SentimentId, st.TagId });

        modelBuilder.Entity<SentimentTag>()
            .HasOne(st => st.Sentiment)
            .WithMany(s => s.SentimentTags)
            .HasForeignKey(st => st.SentimentId);

        modelBuilder.Entity<SentimentTag>()
            .HasOne(st => st.Tag)
            .WithMany(t => t.SentimentTags)
            .HasForeignKey(st => st.TagId);

        base.OnModelCreating(modelBuilder);
    }
}
