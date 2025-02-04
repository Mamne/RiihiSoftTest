namespace RiihiSoftTest.Api.Models
{
    public class PaginatedFeedbackResponse
    {
        public IEnumerable<Feedback>? Feedbacks { get; set; }
        public int TotalCount { get; set; }
    }
}
