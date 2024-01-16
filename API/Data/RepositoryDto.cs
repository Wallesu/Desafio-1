using System.Text.Json.Serialization;

namespace API.Data
{
    public class RepositoryDto
    {
        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("genre")]
        public string Genres { get; set; }

        [JsonPropertyName("song")]
        public string Song { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}
