using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieLibrary
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        public MovieDataHandler movieData = new MovieDataHandler();

        [HttpGet]
        [Route("/toplist")]
        public async Task<IActionResult> GetMovieToplist(bool ascending = true)
        {
            List<Movie> movies;

            try
            {
                movies = movieData.GetMoviesFromJson("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json");
                List<DetailedMovie> detailedMovies = movieData.GetDetailedMoviesFromJson("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json");
                List<Movie> convertedMovies = movieData.ConvertDetailedMovieListToMovieList(detailedMovies);
                movies = movieData.JoinMovieListsWithoutDuplicates(movies, convertedMovies);
            }
            catch
            {
                return StatusCode(500);
            }
            if (movies == null || movies.Count == 0)
            {
                return NoContent();
            }

            movies = movieData.SortMovies(movies, ascending);

            List<string> movieTitles = movieData.GetMovieTitles(movies);

            return Ok(movieTitles);
        }

        [HttpGet]
        [Route("/movie-by-id")]
        public async Task<IActionResult> GetMovieById(string id)
        {
            List<Movie> movies;
            try
            {
                movies = movieData.GetMoviesFromJson("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json");
            }
            catch
            {
                return StatusCode(500);
            }

            if (movies == null || movies.Count == 0)
            {
                return NoContent();
            }
            foreach (var movie in movies)
            {
                if (movie.id.Equals(id))
                {
                    return Ok(movie);
                }
            }
            return NotFound();
        }
    }
}