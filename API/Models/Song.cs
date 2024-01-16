using System.Text.Json.Serialization;

namespace API.Models
{
    public class Song
    {
        public Artist Artist { get; set; }
        public List<Genre> Genres { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }

    }
}
