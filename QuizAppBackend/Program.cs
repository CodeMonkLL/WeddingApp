using Microsoft.EntityFrameworkCore;
using Quizappbackend.Data;

var builder = WebApplication.CreateBuilder(args);

// SQLite-Konfiguration
builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseSqlite("Data Source=quiz.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();