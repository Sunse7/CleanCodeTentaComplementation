using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class Movie
    {
        public string id { get; set; }
        public string title { get; set; }
        public string rated { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        [HttpGet]
        [Route("/toplist")]
        public async Task<IActionResult> MovieToplist(bool ascending = true)
        {
            List<Movie> movieList = new List<Movie>();
            List<Movie> movies = new List<Movie>();
            try
            {
                var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
                movies = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            }
            catch
            {
                return StatusCode(500);
            }

            if (movies == null || movies.Count == 0)
            {
                return NoContent();
            }
            if (ascending)
            {
                movieList = movies.OrderBy(e => e.rated).ToList();
            }
            else
            {
                movieList = movies.OrderByDescending(e => e.rated).ToList(); 
            }
            return Ok(movieList);
        }
        
        [HttpGet]
        [Route("/movie-by-id")]
        public async Task<IActionResult> GetMovieById(string id) 
        {
            var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var movies = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());

            if (movies == null || movies.Count == 0)
            {
                return NoContent();
            }
            foreach (var movie in movies) 
            {
                if (movie.id.Equals((id)))
                {
                    return Ok(movie);
                }
            }
            return NotFound();
        }
    }
}