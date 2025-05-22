using Microsoft.AspNetCore.Mvc;
using Quizappbackend.Data;
using Quizappbackend.Models;

namespace Quizappbackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly QuizDbContext _context;

    public QuizController(QuizDbContext context)
    {
        _context = context;
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitResult([FromBody] UserResult result)
    {
        result.Timestamp = DateTime.UtcNow;
        _context.UserResults.Add(result);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Ergebnis gespeichert." });
    }

    [HttpGet("highscores")]
    public IActionResult GetHighscores()
    {
        var topResults = _context.UserResults
            .OrderByDescending(r => r.Score)
            .Take(10)
            .ToList();

        return Ok(topResults);
    }
}
