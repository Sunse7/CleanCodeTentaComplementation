namespace MovieLibrary
{
    public class DetailedMovieToMovieConverter
    {
        public Movie ConvertDetailedMovieToMovie(DetailedMovie detailedMovie)
        {
            Movie movie = new Movie()
            {
                id = detailedMovie.id,
                title = detailedMovie.title,
                rated = detailedMovie.imdbRating
            };
            return movie;
        }
    }
}
