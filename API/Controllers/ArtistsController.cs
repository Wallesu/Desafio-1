using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly SongService _songService;

        public ArtistsController(SongService songService)
        {
            _songService = songService;
        }

        [Route("[controller]/search-by-genre/{genreName}")]
        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetArtistByGenre(string genreName)
        {
            return Ok(await _songService.GetArtistByGenre(genreName));
        }

        [Route("[controller]/search-songs/{artistName}")]
        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetSongByArtist(string artistName)
        {
            return Ok(await _songService.GetSongByArtist(artistName));
        }
    }
}
