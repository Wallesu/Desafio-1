using API.Models;
using API.Data;
using System.Data;
using static System.StringComparison;

namespace API.Services
{
    public class SongService
    {
        private Repository _repository;
        public SongService(Repository repository)
        {
            _repository = repository;
        }

        public List<Song> GetAllSongs()
        {
            var result = _repository.Data.ToList();
      
            return Utils.ListSong(result);
        }

        public List<Song> GetArtistByGenre(string genreName)
        {
            var result = _repository.Data
                .Where(data => data.Genres.Contains(genreName, CurrentCultureIgnoreCase)).ToList();

            return Utils.ListSong(result);

        }

        public List<Song> GetSongByArtist(string artist)
        {
            var result = _repository.Data
                .Where(data => (data.Artist.StartsWith(artist, CurrentCultureIgnoreCase))).ToList();

            return Utils.ListSong(result);
        }


    }
}
