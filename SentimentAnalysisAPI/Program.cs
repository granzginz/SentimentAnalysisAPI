using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Startups;
public class Program
{
        public static void Main(string[] args)
        {
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                        var services = scope.ServiceProvider;
                        try
                        {
                                var context = services.GetRequiredService<SentimentDbContext>();
                                context.Database.Migrate();
                        }
                        catch (Exception ex)
                        {
                                var logger = services.GetRequiredService<ILogger<Program>>();
                                logger.LogError(ex, "An error occurred while migrating the database.");
                        }
                }

                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                            .ConfigureWebHostDefaults(webBuilder =>
                                        {
                                                webBuilder.UseStartup<Startup>();
                                        });
}