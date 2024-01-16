using API.Data;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ArtistService _artistService;

        public ArtistsController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        [Route("[controller]")]
        [HttpGet]
        public ActionResult<List<Repository>> Get()
        {
            var artists = _artistService.GetAll();
            return Ok(artists);

        }

        [Route("[controller]/Genre")]
        [HttpGet]
        public ActionResult<List<Repository>> GetByGenre(string genre)
        {
            var genres = _artistService.GetByGenre(genre);
            return Ok(genres);

        }
    }
}
