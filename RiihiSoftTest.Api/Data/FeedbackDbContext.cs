using Microsoft.EntityFrameworkCore;
using RiihiSoftTest.Api.Models;

namespace RiihiSoftTest.Api.Data
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }
        public DbSet<Feedback> Feedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, SendersName = "Matti Meikäläinen", SendersEmail = "matti@example.com", Text = "Erinomainen palvelu!", CreatedAt = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc) },
                new Feedback { Id = 2, SendersName = "Maija Virtanen", SendersEmail = "maija@example.com", Text = "Kaikki sujui hienosti.", CreatedAt = new DateTime(2024, 1, 2, 14, 30, 0, DateTimeKind.Utc) },
                new Feedback { Id = 3, SendersName = "Pekka Korhonen", SendersEmail = "pekka@example.com", Text = "Voisi olla parempi.", CreatedAt = new DateTime(2024, 1, 3, 9, 45, 0, DateTimeKind.Utc) },
                new Feedback { Id = 4, SendersName = "Riitta Järvinen", SendersEmail = "riitta@example.com", Text = "Todella ystävällinen palvelu!", CreatedAt = new DateTime(2024, 1, 4, 16, 10, 0, DateTimeKind.Utc) },
                new Feedback { Id = 5, SendersName = "Juha Laine", SendersEmail = "juha@example.com", Text = "Nopea ja luotettava.", CreatedAt = new DateTime(2024, 1, 5, 11, 20, 0, DateTimeKind.Utc) },
                new Feedback { Id = 6, SendersName = "Tiina Mäkinen", SendersEmail = "tiina@example.com", Text = "Ihan ok.", CreatedAt = new DateTime(2024, 1, 6, 10, 0, 0, DateTimeKind.Utc) },
                new Feedback { Id = 7, SendersName = "Antti Salonen", SendersEmail = "antti@example.com", Text = "Ystävällinen ja osaava palvelu.", CreatedAt = new DateTime(2024, 1, 7, 15, 30, 0, DateTimeKind.Utc) },
                new Feedback { Id = 8, SendersName = "Laura Nieminen", SendersEmail = "laura@example.com", Text = "Paljon parannettavaa.", CreatedAt = new DateTime(2024, 1, 8, 8, 50, 0, DateTimeKind.Utc) },
                new Feedback { Id = 9, SendersName = "Jani Kallio", SendersEmail = "jani@example.com", Text = "Olen erittäin tyytyväinen.", CreatedAt = new DateTime(2024, 1, 9, 13, 25, 0, DateTimeKind.Utc) },
                new Feedback { Id = 10, SendersName = "Hanna Heikkinen", SendersEmail = "hanna@example.com", Text = "Paras kokemus ikinä!", CreatedAt = new DateTime(2024, 1, 10, 17, 15, 0, DateTimeKind.Utc) },
                new Feedback { Id = 11, SendersName = "Oskari Rantanen", SendersEmail = "oskari@example.com", Text = "Hyvä ja nopea palvelu.", CreatedAt = new DateTime(2024, 1, 11, 9, 10, 0, DateTimeKind.Utc) },
                new Feedback { Id = 12, SendersName = "Sari Ahonen", SendersEmail = "sari@example.com", Text = "Suosittelen lämpimästi!", CreatedAt = new DateTime(2024, 1, 12, 14, 40, 0, DateTimeKind.Utc) },
                new Feedback { Id = 13, SendersName = "Marko Lehtinen", SendersEmail = "marko@example.com", Text = "Loistava palvelu ja tuki!", CreatedAt = new DateTime(2024, 1, 13, 18, 5, 0, DateTimeKind.Utc) }
            );
        }
    }
}
