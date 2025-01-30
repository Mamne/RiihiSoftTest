//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiihiSoftTest.Api.Data;
using RiihiSoftTest.Api.Models;

namespace RiihiSoftTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackDbContext _context;

        public FeedbackController(FeedbackDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFeedback), new { id = feedback.Id }, feedback);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
        {
            return await _context.Feedbacks.ToListAsync();
        }
    }
}
