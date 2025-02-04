using RiihiSoftTest.Api.Models;
namespace RiihiSoftTest.Api.Interfaces
{
    public interface IFeedbackService
    {
        Task<Feedback> AddFeedbackAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();
        Task<IEnumerable<Feedback>> GetPaginatedFeedbacksAsync(int pageNumber, int pageSize);
        Task<int> GetTotalFeedbackCountAsync();
    }
}
