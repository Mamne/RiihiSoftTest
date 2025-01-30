namespace RiihiSoftTest.Api.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string SendersName { get; set; }
        public string SendersEmail { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
