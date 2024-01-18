using API.Models;
using API.Data;
using System.Data;
using static System.StringComparison;

namespace API.Services
{
    public class SongService
    {
        private readonly Repository _repository;
        public SongService(Repository repository)
        {
            _repository = repository;
        }

        public Task<List<Song>> GetAllSongs()
        {
            var result = _repository.Data;
      
            return Task.FromResult(Utils.ListSong(result));
        }

        public Task<List<Song>> GetArtistByGenre(string genreName)
        {
            var result = _repository.Data
                .Where(data => data.Genres.Contains(genreName, CurrentCultureIgnoreCase)).ToList();

            return Task.FromResult(Utils.ListSong(result));

        }

        public Task<List<Song>> GetSongByArtist(string artist)
        {
            var result = _repository.Data
                .Where(data => (data.Artist.StartsWith(artist, CurrentCultureIgnoreCase))).ToList();

            return Task.FromResult(Utils.ListSong(result));
        }


    }
}
