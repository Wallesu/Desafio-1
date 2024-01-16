using API.Data;
using API.Models;
using System.Text.Json;

namespace API.Services
{
    public class GenreService
    {
        private Repository _repository;
        public GenreService(Repository repository)
        {
            _repository = repository;
        }
        public List<Genre> GetAll()
        {
            var genresStr = _repository.Data.SelectMany(song => song.Genres.Split(", ")).Select(genre => genre.Trim()).Distinct();
            List<Genre> genres = new List<Genre>();
            foreach (var genre in genresStr)
            {
                genres.Add(new Genre { Name = genre });
            }

            return genres;

        }
    }
}
