﻿using System.Text.Json;

namespace API.Data
{
    public class Repository
    {
        public List<RepositoryDto> Data { get; set; }

        public Repository()
        {
            using HttpClient client = new();

            using Stream stream = client.GetStreamAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json").Result;

            var data = JsonSerializer.DeserializeAsync<List<RepositoryDto>>(stream).Result;
            Data = data.ToList();
        }
    }
}
