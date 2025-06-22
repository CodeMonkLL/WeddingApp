using Microsoft.EntityFrameworkCore;
using Quizappbackend.Data;

var builder = WebApplication.CreateBuilder(args);

// SQLite-Konfiguration
builder.Services.AddDbContext<WeddingDbContext>(options =>
    options.UseSqlite("Data Source=Data/Wedding.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://0.0.0.0:8080");
var app = builder.Build();

// Migration beim Start ausführen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WeddingDbContext>();
    db.Database.Migrate();
}


// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();