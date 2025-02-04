namespace RiihiSoftTest.Api.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public required string SendersName { get; set; }
        public string SendersEmail { get; set; } = string.Empty;
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
