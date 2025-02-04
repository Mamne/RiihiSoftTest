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

            var createdFeedback = await _feedbackService.AddFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetFeedback), new { id = createdFeedback.Id }, createdFeedback);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginatedFeedbackResponse>> GetPaginatedFeedback([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

            var feedbacks = await _feedbackService.GetPaginatedFeedbacksAsync(pageNumber, pageSize);
            var totalCount = await _feedbackService.GetTotalFeedbackCountAsync();

            var response = new PaginatedFeedbackResponse
            {
                Feedbacks = feedbacks,
                TotalCount = totalCount
            };

            return Ok(response);
        }
    }
}
