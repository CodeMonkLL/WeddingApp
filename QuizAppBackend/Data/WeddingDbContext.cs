using Microsoft.EntityFrameworkCore;
using Quizappbackend.Models;

namespace Quizappbackend.Data;

public class WeddingDbContext : DbContext
{
    public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options) { }

    public DbSet<UserResult> UserResults { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<GuestbookEntry> GuestbookEntries { get; set; }
}