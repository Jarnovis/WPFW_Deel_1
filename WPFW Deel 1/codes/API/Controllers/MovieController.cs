using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPFW_Deel_1.codes.API.DTO;

namespace WPFW_Deel_1.codes.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MovieController : ControllerBase
{
    private readonly MovieDataBaseContext context = new MovieDataBaseContext();

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
    {
        var movies = await context.movies.Include(m => m.director).Include(m => m.review).ToListAsync();

        var result = movies.Select(m => new MovieDTO
        {
            title = m.title,
            year = m.year,
            director = m.director.Select(d => d.name).ToList(),
            review = m.review.Select(r => r.description).ToList()
        });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDTO>> GetMovie(int id)
    {
        var movie = await context.movies.Include(m => m.review).Include(m => m.director).FirstOrDefaultAsync(m => m.id == id);

        if (movie == null)
        {
            return NotFound();
        }

        MovieDTO result = new MovieDTO
        {
            title = movie.title,
            year = movie.year,
            director = movie.director.Select(d => d.name).ToList(),
            review = movie.review.Select(r => r.description).ToList()
            };

        return Ok(result);
    }


    [HttpPost("{title}/{year}/{director}")]
        public async Task<IResult> PostMovie(string title, int year, string director)
        {

            if (!movieExists(title, year))
            {
                Director isDirector;

                if (!directorExists(director))
                {
                    isDirector = createDirector(director);
                }
                else
                {
                    isDirector = context.directors.Where(d => d.name.ToLower().Equals(director.ToLower())).FirstOrDefault();
                }

                Movie movie = new Movie()
                {
                    title = title,
                    year = year,
                    director = new List<Director>()
                };

                movie.director.Add(isDirector);

                await context.movies.AddAsync(movie);
                await context.SaveChangesAsync();

                return Results.Ok(new {message = $"{title} is succesfully added to the db"});
            }
            
            return Results.Ok(new {message = $"{title} does allready exists in the db with the year {year}"});
        }

        private bool movieExists(string title, int year)
        {
            return context.movies.Any(m => m.title.Trim().ToLower().Equals(title.ToLower()) && m.year == year);
        }

        private bool directorExists(string name)
        {
            return context.directors.Any(d => d.name.Trim().ToLower().Equals(name.ToLower()));
        }

        private Director createDirector(string name)
        {
            Director director = new Director()
            {
                name = name
            };

            context.directors.Add(director);

            return director;
        }
        

}