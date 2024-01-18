using API.Services;
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

        [Route("[controller]/show-all")]
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            var songs = _songService.GetAllSongs();
            return Ok(songs);

        }
    }
}
