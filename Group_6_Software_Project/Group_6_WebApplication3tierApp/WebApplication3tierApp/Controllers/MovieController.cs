using _2DataAccessLayer.Services;
using _3BusinessLogicLayer.Interfaces;
using _3BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3tierApp.Models;

namespace WebApplication3tierApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MovieController : BaseController
    {

        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;
        private readonly ISecurityService _securityService;
       
        public MovieController(IMovieService movieService, ILogger<MovieController> logger, ISecurityService securityService)
        {
            _movieService = movieService;
            _logger = logger;
            _securityService = securityService;
        }

        [HttpGet("", Name = "GetAllMovies")]
        public async Task<List<MovieDto>> GetAll()
        {
            var result = await _movieService.GetAll();
            return result.Select(x => x.ToMovieDto()).ToList();
        }

        [HttpGet("{MovieId}", Name = "GetMovie")]
        public async Task<MovieDto?> Get(int MovieId)
        {
            var result = await _movieService.GetById(MovieId);
            return result?.ToMovieDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] MovieDto requestDto)
        {
            var movieModel = requestDto.ToMovieModel();
            return await _movieService.CreateMovie(movieModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] MovieDto requestDto)
        {
            await _movieService.UpdateMovie(requestDto.ToMovieModel());
            return Ok();
        }

        [HttpDelete, Route("{MovieId}")]
        public async Task<IActionResult> Delete(int MovieId)
        {
            await _movieService.DeleteMovie(MovieId);
            return Ok();
        }
    }
}
