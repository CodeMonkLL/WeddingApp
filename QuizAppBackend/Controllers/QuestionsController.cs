using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizappbackend.Data;
using Quizappbackend.Models;

namespace Quizappbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizDbContext _context;
        public QuestionsController(QuizDbContext context)
        {
            _context = context;
        }

    }
}