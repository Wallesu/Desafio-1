using System.Text.Json.Serialization;

namespace API.Models
{
    public class Song
    {
        public Artist Artist { get; set; }
        public List<Genre> Genres { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public int DurationMs { get; set; }
        public string Popularity { get; set; }
        public string Danceability { get; set; }
        public string Energy { get; set; }
        public int Key { get; set; }
        public string Loudness { get; set; }
        public string Mode { get; set; }

    }
}
