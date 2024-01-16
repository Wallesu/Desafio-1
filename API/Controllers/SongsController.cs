using API.Services;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    public class SongsController : ControllerBase
    {
        private SongService _songService;

        public SongsController(SongService songService)
        {
            _songService = songService;
        }

        [Route("[controller]")]
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get(string? artistName, string? songName, string? genreName)
        {
            var songs = _songService.GetAll(artistName, songName, genreName);
            return Ok(songs);

        }
    }
}
