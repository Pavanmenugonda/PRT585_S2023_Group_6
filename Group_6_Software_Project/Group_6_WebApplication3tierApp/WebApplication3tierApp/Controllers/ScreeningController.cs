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
    public class ScreeningController : BaseController
    {

        private readonly IScreeningService _screeningService;
        private readonly ILogger<ScreeningController> _logger;
        private readonly ISecurityService _securityService;
       
        public ScreeningController(IScreeningService movieService, ILogger<ScreeningController> logger, ISecurityService securityService)
        {
            _screeningService = movieService;
            _logger = logger;
            _securityService = securityService;
        }

        [HttpGet("", Name = "GetAllScreenings")]
        public async Task<List<ScreeningDto>> GetAll()
        {
            var result = await _screeningService.GetAll();
            return result.Select(x => x.ToScreeningDto()).ToList();
        }

        [HttpGet("{ScreeningId}", Name = "GetScreening")]
        public async Task<ScreeningDto?> Get(int ScreeningId)
        {
            var result = await _screeningService.GetById(ScreeningId);
            return result?.ToScreeningDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] ScreeningDto requestDto)
        {
            var movieModel = requestDto.ToScreeningModel();
            return await _screeningService.CreateScreening(movieModel);
        }

        [HttpPut, Route("{ScreeningId}")]
        public async Task<IActionResult> Update([FromBody] ScreeningDto requestDto)
        {
            requestDto.ScreeningId = int.Parse(HttpContext.Request.RouteValues["ScreeningId"].ToString());
            await _screeningService.UpdateScreening(requestDto.ToScreeningModel());
            return Ok();
        }

        [HttpDelete, Route("{ScreeningId}")]
        public async Task<IActionResult> Delete(int ScreeningId)
        {
            await _screeningService.DeleteScreening(ScreeningId);
            return Ok();
        }
    }
}
