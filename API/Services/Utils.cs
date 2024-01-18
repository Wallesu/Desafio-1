using API.Data;
using API.Models;

namespace API.Services
{
    public class Utils
    {
        public static List<Song> ListSong(List<RepositoryDto> result)
        {
            
            if (result == null) return new List<Song>();

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
