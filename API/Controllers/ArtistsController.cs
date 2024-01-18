using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private SongService _songService;

        public ArtistsController(SongService songService)
        {
            _songService = songService;
        }

        [Route("[controller]/search-by-genre/{genreName}")]
        [HttpGet]
        public ActionResult<List<Song>> GetArtistByGenre(string genreName)
        {
            var artists = _songService.GetArtistByGenre(genreName);
            return Ok(artists);

        }

        [Route("[controller]/search-songs/{artistName}")]
        [HttpGet]
        public ActionResult<List<Song>> GetSongByArtist(string artistName)
        {
            List<Song> songs = _songService.GetSongByArtist(artistName);
            return Ok(songs);

        }
    }
}
