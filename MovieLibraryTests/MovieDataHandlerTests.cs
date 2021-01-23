using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary;
using System.Collections.Generic;

namespace MovieLibraryTests
{
    [TestClass]
    public class MovieDataHandlerTests
    {
        [TestMethod]
        public void GivenAListOfMovies_ReturnsThemSortedByRating()
        {
            MovieDataHandler movieData = new MovieDataHandler();
           
            List<Movie> movieList = new List<Movie>()
            {
                new Movie()
                {
                    id = "1",
                    title = "Lucky the Movie",
                    rated = "8"
                },
                new Movie()
                {
                    id = "2",
                    title = "Azmodan Lord of Sin",
                    rated = "9"
                },
                new Movie()
                {
                    id = "3",
                    title = "Firefox the Cat",
                    rated = "7"
                }
            };

            List<Movie> expected = new List<Movie>()
            {
                new Movie()
                {
                    id = "3",
                    title = "Firefox the Cat",
                    rated = "7"
                },
                new Movie()
                {
                    id = "1",
                    title = "Lucky the Movie",
                    rated = "8"
                },
                new Movie()
                {
                    id = "2",
                    title = "Azmodan Lord of Sin",
                    rated = "9"
                }               
            };


            var actual = movieData.SortMovies(movieList);
            Assert.AreEqual(expected[0].rated, actual[0].rated);
            Assert.AreEqual(expected[1].rated, actual[1].rated);
            Assert.AreEqual(expected[2].rated, actual[2].rated);

        }
    }
}
