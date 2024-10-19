using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WPFW_Deel_1.codes.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MovieController : ControllerBase
{
    private readonly MovieDataBaseContext context;

    public MovieController (MovieDataBaseContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await context.movies.Include(m => m.director).Include(m => m.review).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await context.movies.Include(m => m.director).FirstOrDefaultAsync(m => m.id == id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> PostMovie(Movie movie)
    {
        context.movies.Add(movie);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMovie), new {id = movie.id}, movie);
    }

    [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.id)
            {
                return BadRequest();
            }

            context.Entry(movie).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetMovie(id).Equals(NotFound()))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

}