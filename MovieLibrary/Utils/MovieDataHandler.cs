using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace MovieLibrary
{
    public class MovieDataHandler
    {
        static HttpClient client = new HttpClient();

        public List<Movie> GetMoviesFromJson(string url)
        {
            var result = client.GetAsync(url).Result;
            var movies = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            return movies;
        }

        public List<DetailedMovie> GetDetailedMoviesFromJson(string url)
        {
            var result = client.GetAsync(url).Result;
            var movies = JsonSerializer.Deserialize<List<DetailedMovie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            return movies;
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
