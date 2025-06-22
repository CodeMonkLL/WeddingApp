using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizappbackend.Data;
using Quizappbackend.Models;

namespace Quizappbackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Usercontroller : ControllerBase
{
    private readonly WeddingDbContext _context;

    public Usercontroller(WeddingDbContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<ActionResult<UserResult>> PostUser(UserResult user)
    {
        var existingUser = await _context.UserResults
        .FirstOrDefaultAsync(u => u.Username == user.Username);

        if (existingUser != null)
        {
            return Conflict($"Username '{user.Username}' already exists.");
        }

        _context.UserResults.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserByName), new { user = user.Id }, user);
    }

    [HttpGet("User")]
    public async Task<ActionResult<UserResult>> GetUserByName(string name)
    {
        var user = await _context.UserResults.FirstOrDefaultAsync(u => u.Username == name);

        if (user == null)
        {
            return NotFound($"User not found :{name}");
        }

        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<UserResult>> GetAllUsers()
    {
        List<UserResult> listOfUsers = await _context.UserResults.ToListAsync();
        return Ok(listOfUsers);
    }
}
