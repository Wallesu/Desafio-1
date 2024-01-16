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
        public async Task<ActionResult<IEnumerable<Song>>> Get(string? artistName, string? search)
        {
            var songs = await _songService.GetAllAsync(artistName, search);
            return Ok(songs);

        }

        [Route("[controller]/Artist/{artistName}")]
        [HttpGet]
        public ActionResult<List<Song>> GetByArtist(string artistName, string? search)
        {
            List<Song> songs = _songService.GetByArtist(artistName, search);
            return Ok(songs);

        }
    }
}
