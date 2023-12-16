namespace Startups
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers();

            services.AddDbContext<SentimentDbContext>(options =>
            {
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    new MariaDbServerVersion(new Version(8, 0, 30))
                );
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sentiment Analysis API v1");
                    c.RoutePrefix = string.Empty;
                });

                app.UseCors();
                app.UseHttpsRedirection();

                app.UseAuthorization();
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            }
        }
    }
}