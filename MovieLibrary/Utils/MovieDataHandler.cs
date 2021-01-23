using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieDataHandler
    {
        static HttpClient client = new HttpClient();

        public async Task<List<Movie>> GetMoviesFromJson(string url)
        {
            string json = await client.GetStringAsync(url);
            List<Movie> movies = new List<Movie>();
            JsonConvert.PopulateObject(json, movies);
            return movies;
        }

        public async Task<List<DetailedMovie>> GetDetailedMoviesFromJson(string url)
        {
            string json = await client.GetStringAsync(url);
            List<DetailedMovie> detailedMovies = new List<DetailedMovie>();
            JsonConvert.PopulateObject(json, detailedMovies);
            return detailedMovies;
        }

        public List<Movie> SortMovies(List<Movie> movies, bool ascending = true)
        {
            if (ascending)
            {
                movies = movies.OrderBy(e => e.rated).ToList();
            }
            else
            {
                movies = movies.OrderByDescending(e => e.rated).ToList();
            }
            return movies;
        }

        public List<string> GetMovieTitles(List<Movie> movies)
        {
            List<string> movieList = new List<string>();
            foreach (var movie in movies)
            {
                movieList.Add(movie.title);
            }
            return movieList;
        }

        public List<Movie> JoinMovieListsWithoutDuplicates(List<Movie> moviesA, List<Movie> moviesB)
        {
            List<Movie> combinedMovieList = new List<Movie>();
            foreach (var movie in moviesA)
            {
                combinedMovieList.Add(movie);
            }
            foreach (var movie in moviesB)
            {
                if(!combinedMovieList.Where(m => m.title == movie.title).Any())
                    combinedMovieList.Add(movie);
            }
            return combinedMovieList;
        }

        public List<Movie> ConvertDetailedMovieListToMovieList(List<DetailedMovie> detailedMovies)
        {
            DetailedMovieToMovieConverter movieConverter = new DetailedMovieToMovieConverter();
            List<Movie> convertedMovies = new List<Movie>();
            foreach (var movie in detailedMovies)
            {
                Movie convertedMovie = movieConverter.ConvertDetailedMovieToMovie(movie);
                convertedMovies.Add(convertedMovie);
            }
            return convertedMovies;
        }
    }
}
