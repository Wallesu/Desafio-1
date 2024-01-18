using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class GenresController : ControllerBase
    {
        private GenreService _genreService;

        public GenresController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [Route("[controller]/show-all-genres")]
        [HttpGet]
        public ActionResult<List<string>> GetAllGenres()
        {
            var repository = _genreService.GetAllGenres();
            return Ok(repository);

        }
    }
}
