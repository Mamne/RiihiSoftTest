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
            try
            {
                _dbContext.Feedbacks.Add(feedback);
                await _dbContext.SaveChangesAsync();
                return feedback;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while adding feedback.", ex);
            }
        }


        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            try
            {
                return await _dbContext.Feedbacks.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving feedbacks.", ex);
            }
        }

        public async Task<IEnumerable<Feedback>> GetPaginatedFeedbacksAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _dbContext.Feedbacks
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving paginated feedbacks.", ex);
            }
        }

        public async Task<int> GetTotalFeedbackCountAsync()
        {
            try
            {
                return await _dbContext.Feedbacks.CountAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving feedback count.", ex);
            }
        }
    }
}
