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
        public async Task<ActionResult<IEnumerable<Song>>> Get(string? artistName, string? songName)
        {
            var songs = await _songService.GetAllAsync(artistName, songName);
            return Ok(songs);

        }
    }
}
