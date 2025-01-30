using Microsoft.EntityFrameworkCore;
using RiihiSoftTest.Api.Models;

namespace RiihiSoftTest.Api.Data
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }
        public DbSet<Feedback> Feedbacks { get; set; } 
    }
}
