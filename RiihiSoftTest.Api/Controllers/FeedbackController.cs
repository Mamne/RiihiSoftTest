using Microsoft.AspNetCore.Mvc;
using RiihiSoftTest.Api.Interfaces;
using RiihiSoftTest.Api.Models;

namespace RiihiSoftTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdFeedback = await _feedbackService.AddFeedbackAsync(feedback);
                return CreatedAtAction(nameof(GetFeedback), new { id = createdFeedback.Id }, createdFeedback);
            }
            catch (Exception)
            {
                return Problem("An unexpected error occurred while processing your request.", statusCode: 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
        {
            try
            {
                var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
                return Ok(feedbacks);
            }
            catch (Exception)
            {
                return Problem("An unexpected error occurred while retrieving feedback.", statusCode: 500);
            }
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginatedFeedbackResponse>> GetPaginatedFeedback([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

            try
            {
                var feedbacks = await _feedbackService.GetPaginatedFeedbacksAsync(pageNumber, pageSize);
                var totalCount = await _feedbackService.GetTotalFeedbackCountAsync();

                var response = new PaginatedFeedbackResponse
                {
                    Feedbacks = feedbacks,
                    TotalCount = totalCount
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return Problem("An unexpected error occurred while trying to retrieve the paginated feedbacks.", statusCode: 500);
            }
        }
    }
}
