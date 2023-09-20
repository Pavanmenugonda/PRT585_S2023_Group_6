using _1CommonInfrastructure.Models;
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
    public class TicketController : BaseController
    {

        private readonly ITicketService _movieService;
        private readonly ILogger<TicketController> _logger;
        private readonly ISecurityService _securityService;
       
        public TicketController(ITicketService movieService, ILogger<TicketController> logger, ISecurityService securityService)
        {
            _movieService = movieService;
            _logger = logger;
            _securityService = securityService;
        }


        [HttpGet("", Name = "GetAllTickets")]
        public async Task<List<TicketDto>> GetAll()
        {
            var result = await _movieService.GetAll();
            return result.Select(x => x.ToTicketDto()).ToList();
        }

        [HttpGet("{TicketId}", Name = "GetTicket")]
        public async Task<TicketDto?> Get(int TicketId)
        {
            var result = await _movieService.GetById(TicketId);
            return result?.ToTicketDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] TicketDto requestDto)
        {
            var movieModel = requestDto.ToTicketModel();
            return await _movieService.CreateTicket(movieModel);
        }

        [HttpPut, Route("{TicketId}")]
        public async Task<IActionResult> Update([FromBody] TicketDto requestDto)
        {
            requestDto.TicketID = int.Parse(HttpContext.Request.RouteValues["TicketId"].ToString());
            await _movieService.UpdateTicket(requestDto.ToTicketModel());
            return Ok();
        }

        [HttpDelete, Route("{TicketId}")]
        public async Task<IActionResult> Delete(int TicketId)
        {
            await _movieService.DeleteTicket(TicketId);
            return Ok();
        }
    }
}
