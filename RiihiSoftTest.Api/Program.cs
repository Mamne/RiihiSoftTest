
using Microsoft.EntityFrameworkCore;
using RiihiSoftTest.Api.Data;
using RiihiSoftTest.Api.Interfaces;
using RiihiSoftTest.Api.Services;

namespace RiihiSoftTest.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:50995", "https://localhost:50995")
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });


            // Add services to the container.
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();
            builder.Services.AddDbContext<FeedbackDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<FeedbackDbContext>();
                dbContext.Database.EnsureCreated();
            }
            
            app.UseCors("AllowFrontend");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
