using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizappbackend.Data;
using SQLitePCL;


namespace QuizAppBackend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class GuestbookController : ControllerBase
{
    private readonly WeddingDbContext _context;
    public GuestbookController(WeddingDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GuestbookEntry>>> GetGuestbookentries()
    {
        return await _context.GuestbookEntries.ToListAsync();
    }

    [HttpGet("{ID}")]
    public async Task<ActionResult<GuestbookEntry>> GetGuestbookentryById(int id)
    {
        var guestbookentry = await _context.GuestbookEntries.FindAsync(id);

        if (guestbookentry == null)
        {
            return NotFound();
        }

        return Ok(guestbookentry);
    }

    [HttpGet("Name")]
    public async Task<ActionResult<GuestbookEntry>> GetGuestbookentryById(string Name)
    {
        var guestbookentry = await _context.GuestbookEntries.FindAsync(Name);

        if (guestbookentry == null)
        {
            return NotFound();
        }

        return Ok(guestbookentry);
    }

    [HttpPost]
    public async Task<ActionResult<GuestbookEntry>> PostGuestbookEntry(GuestbookEntry guestbookEntry)
    {
        _context.GuestbookEntries.Add(guestbookEntry);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGuestbookentriesById(int id)
    {
        var guestbookEntry = await _context.GuestbookEntries.FindAsync(id);
        if (guestbookEntry == null)
        {
            return NotFound();
        }
        _context.GuestbookEntries.Remove(guestbookEntry);
        await _context.SaveChangesAsync();
        return Ok("Objekt wurde gelöscht");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllGuestbookentries()
    {
        var entries = await _context.GuestbookEntries.ToListAsync();
        if (entries == null)
        {
            return NotFound();
        }

        _context.GuestbookEntries.RemoveRange(entries);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
