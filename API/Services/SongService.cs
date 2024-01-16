using API.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using API.Data;
using System.Data;
using Microsoft.AspNetCore.Mvc;


namespace API.Services
{
    public class SongService
    {
        private Repository _repository;
        public SongService(Repository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Song>> GetAllAsync(string? artist, string? songName)
        {
            var result = _repository.Data
                .Where(song => (artist != null ? song.Artist.ToLower().Contains(artist.ToLower()) : 1 == 1) && (songName != null ? song.Song.ToLower().Contains(songName.ToLower()) : 1 == 1));

            var songsStr = await Task.FromResult(result);

            List<Song> songs = new List<Song>();
            foreach (var song in songsStr)
            {
                string[] genresStr = song.Genres.Split(", ");
                List<Genre> genres = new List<Genre>();
                foreach (var genre in genresStr)
                {
                    genres.Add(new Genre { Name = genre });
                }

                songs.Add(new Song
                {
                    Name = song.Song,
                    Year = song.Year,
                    Artist = new Artist { Name = song.Artist },
                    Genres = genres
                });
            }

            return songs;
        }
        public List<Song> GetByArtist(string artist, string? songName)
        {
            var songsStr = _repository.Data
                .Where(song => (song.Artist.ToLower() == artist.ToLower()) && (songName != null ? song.Song.ToLower().Contains(songName.ToLower()) : 1 == 1))
                .ToList();

            List<Song> songs = new List<Song>();
            foreach (var song in songsStr)
            {
                string[] genresStr = song.Genres.Split(", ");
                List<Genre> genres = new List<Genre>();
                foreach (var genre in genresStr)
                {
                    genres.Add(new Genre { Name = genre });
                }

                songs.Add(new Song
                {
                    Name = song.Song,
                    Year = song.Year,
                    Artist = new Artist { Name = song.Artist },
                    Genres = genres
                });
            }

            return songs;
        }
    }
}
