using Microsoft.EntityFrameworkCore;
using RiihiSoftTest.Api.Data;
using RiihiSoftTest.Api.Interfaces;
using RiihiSoftTest.Api.Models;

namespace RiihiSoftTest.Api.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly FeedbackDbContext _dbContext;
        public FeedbackService(FeedbackDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            _dbContext.Feedbacks.Add(feedback);
            await _dbContext.SaveChangesAsync();
            return feedback;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetPaginatedFeedbacksAsync(int pageNumber, int pageSize)
        {
            var feedbacks = await _dbContext.Feedbacks
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return feedbacks;
        }

        public async Task<int> GetTotalFeedbackCountAsync()
        {
            return await _dbContext.Feedbacks.CountAsync();
        }
    }
}
