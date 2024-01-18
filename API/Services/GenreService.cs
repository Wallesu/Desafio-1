using API.Data;

namespace API.Services
{
    public class GenreService
    {
        private readonly Repository _repository;
        public GenreService(Repository repository)
        {
            _repository = repository;
        }

        public List<string> GetAllGenres()
        {
            var genresStr = _repository.Data
                .SelectMany(song => song.Genres.Split(", "))
                .Select(genre => genre.Trim())
                .Distinct().ToList();

            var genres = new List<string>();

            foreach (var genre in genresStr)
            {
                genres.Add(genre);
            }

            return genres;

        }
    }
}
