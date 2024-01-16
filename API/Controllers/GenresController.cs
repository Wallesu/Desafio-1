using API.Data;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class GenresController : ControllerBase
    {
        private ArtistService _artistService;
        private GenreService _genreService;

        public GenresController(GenreService genreService, ArtistService artistService)
        {
            _genreService = genreService;
            _artistService = artistService;
        }

        [Route("[controller]")]
        [HttpGet]
        public ActionResult<List<Repository>> Get()
        {
            var repository = _genreService.GetAll();
            return Ok(repository);

        }

        [Route("[controller]/{genreName}/Artists")]
        [HttpGet]
        public ActionResult<List<Repository>> GetByGenre(string genreName)
        {
            var genres = _artistService.GetByGenre(genreName);
            return Ok(genres);

        }
    }
}
