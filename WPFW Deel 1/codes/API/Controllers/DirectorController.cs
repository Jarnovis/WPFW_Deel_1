using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WPFW_Deel_1.codes.API.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class DirectorController : ControllerBase
{
    private readonly MovieDataBaseContext context = new MovieDataBaseContext();

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Director>>> GetDirectors()
    {
        return await context.directors.Include(d => d.movies).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Director>> GetDirector(int id)
    {
        var result = await context.directors.Include(d => d.movies).FirstOrDefaultAsync(d => d.id == id);

        if (result == null)
        {
            return NotFound();
        }

        return result;
    }

    [HttpPost("Name")]
    public async Task<IResult> CreateDirector(string name)
    {
        if (!DirectorExists(name))
        {
            Director director = new Director()
            {
                name = name
            };

            await context.directors.AddAsync(director);
            await context.SaveChangesAsync();
            
            return Results.Ok(new {message = $"Director {name} is succesfully added to the db"});
        }

        return Results.Ok(new {message = $"{name} allready in db"});
    }

    private bool DirectorExists(string name)
    {
        return context.directors.Any(d => d.name.Trim().ToLower().Equals(name.Trim().ToLower()));
    }
}