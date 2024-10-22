using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPFW_Deel_1.codes.API.DTO;

namespace WPFW_Deel_1.codes.API.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class DirectorController : ControllerBase
{
    private readonly MovieDataBaseContext context = new MovieDataBaseContext();

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DirectorDTO>>> GetDirectors()
    {
        var directors = await context.directors.Include(d => d.movies).Select(d => new DirectorDTO
        {
            name = d.name,
            movies = d.movies.Select(m => m.title).ToList()
        }).ToListAsync();

        return Ok(directors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DirectorDTO>> GetDirector(int id)
    {
        var result = await context.directors.Include(d => d.movies).FirstOrDefaultAsync(d => d.id == id);

        if (result == null)
        {
            return NotFound();
        }

        var directorDTO = new DirectorDTO
        {
            name = result.name,
            movies = result.movies.Select(m => m.title).ToList()
        };

        return directorDTO;
    }

    // For usage of adding the DirectorDTO, you need to have this class allready made,
    // because of swagger, you do not have a DirectorDTO object avalable
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