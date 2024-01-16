using API.Data;
using API.Models;

namespace API.Services
{
    public class ArtistService
    {
        private Repository _repository;
        public ArtistService(Repository repository)
        {
            _repository = repository;
        }
        public List<Artist> GetAll(string? genreName)
        {
            var artistsStr = _repository.Data
                .Where(song => genreName != null ? song.Genres.Contains(genreName) : true)
                .Select(song => song.Artist)
                .OrderBy(artist => artist)
                .Distinct();
            List<Artist> artists = new List<Artist>();
            foreach (var artist in artistsStr)
            {
                artists.Add(new Artist { Name = artist });
            }

            return artists;

        }
        public List<Artist> GetByGenre(string genre)
        {
            var artistsStr = _repository.Data
            .Where(song => song.Genres.Split(", ").Select(g => g.Trim().ToLower()).Contains(genre.ToLower()))
            .Select(song => song.Artist)
            .OrderBy(artist => artist)
            .Distinct();

            List<Artist> artists = new List<Artist>();
            foreach (var artist in artistsStr)
            {
                artists.Add(new Artist { Name = artist });
            }

            return artists;
        }
    }
}
