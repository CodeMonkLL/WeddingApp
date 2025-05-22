using Microsoft.EntityFrameworkCore;
using Quizappbackend.Models;

namespace Quizappbackend.Data;

public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

    public DbSet<UserResult> UserResults { get; set; }
    public DbSet<Question> Questions { get; set; }
}