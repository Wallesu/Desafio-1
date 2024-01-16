using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ArtistService _artistService;
        private SongService _songService;

        public ArtistsController(ArtistService artistService, SongService songService)
        {
            _artistService = artistService;
            _songService = songService;
        }

        [Route("[controller]")]
        [HttpGet]
        public ActionResult<List<Repository>> Get()
        {
            var artists = _artistService.GetAll();
            return Ok(artists);

        }

        [Route("[controller]/{artistName}/Songs")]
        [HttpGet]
        public ActionResult<List<Song>> GetByArtist(string artistName, string? songName)
        {
            List<Song> songs = _songService.GetByArtist(artistName, songName);
            return Ok(songs);

        }
    }
}
