namespace Quizappbackend.Models;

public class UserResult
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public int Score { get; set; }
    public DateTime Timestamp { get; set; }
}