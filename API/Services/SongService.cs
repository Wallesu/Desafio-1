using API.Models;
using API.Data;
using System.Data;


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
            var songsList = new List<Song>();

            foreach (var song in result)
            {
                songsList.Add(new Song
                {
                    Name = song.Song,
                    Year = song.Year,
                    Artist = song.Artist,
                    Genre = song.Genres
                });
            }

            return songsList;
        }

        public List<Song> GetArtistByGenre(string genreName)
        {
            var result = _repository.Data.Where(data => data.Genres.ToLower().Contains(genreName.ToLower()));

            var songsList = new List<Song>();

            foreach (var song in result)
            {
                songsList.Add(new Song 
                {
                    Name = song.Song,
                    Year = song.Year,
                    Artist = song.Artist,
                    Genre = song.Genres
                });
            }

            return songsList;

        }

        public List<Song> GetSongByArtist(string artist)
        {
            var result = _repository.Data
                .Where(data => (data.Artist.ToLower().StartsWith(artist.ToLower())));

            var songsList = new List<Song>();

            foreach (var song in result)
            {
                songsList.Add(new Song
                {
                    Name = song.Song,
                    Year = song.Year,
                    Artist = song.Artist,
                    Genre = song.Genres
                });
            }

            return songsList;
        }
    }
}
