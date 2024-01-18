using System.Text.Json.Serialization;

namespace API.Models
{
    public class Song
    {
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }

    }
}
