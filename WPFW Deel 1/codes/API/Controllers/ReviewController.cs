using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WPFW_Deel_1.codes.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ReviewController : ControllerBase
{
    private readonly MovieDataBaseContext context = new MovieDataBaseContext();

    [HttpGet]
    public async Task<IEnumerable<Review>> getReviews()
    {
        return await context.reviews.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> getReview(int id)
    {
        var review = await context.reviews.FirstOrDefaultAsync(r => r.id == id);

        if (review == null)
        {
            return NotFound();
        }

        return review;
    }

    [HttpPost("{rating}/{description}/{userName}/{movieTitle}")]
    public async Task<IResult> PostReview(int rating, string description, string userName, string movieTitle)
    {
        if (checkMovie(movieTitle))
        {
            int movieId = await context.movies.Where(m => m.title.Trim().ToLower().Equals(movieTitle.Trim().ToLower())).Select(m => m.id).FirstOrDefaultAsync();

            Review review = new Review()
            {
                rating = rating,
                description = description,
                userName = userName,
                createdAt = DateTime.Now,
                movieId = movieId
            };

            await context.reviews.AddAsync(review);
            await context.SaveChangesAsync();

            return Results.Ok(new {message = $"Review for {movieTitle} is posted"});
        }

        return Results.Ok(new {message = $"Movie {movieTitle} does not exists in the db"});
    }

    private bool checkMovie(string movieTitle)
    {
        return context.movies.Any(m => m.title.Trim().ToLower().Equals(movieTitle.Trim().ToLower()));
    }
}