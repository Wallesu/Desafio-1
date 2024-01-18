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

        public List<Song> GetArtistByGenre(string genreName)
        {
            var artistsStr = _repository.Data
                .Where(song => genreName != null ? song.Genres.Contains(genreName) : true)
                .Select(song => song.Artist)
                .OrderBy(artist => artist)
                .Distinct();

            var artists = new List<Song>();

            foreach (var ar in artistsStr)
            {
                
            }

            return artists;

        }
    }
}
