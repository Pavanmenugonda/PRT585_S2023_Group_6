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
    public class PaymentController : BaseController
    {

        private readonly IPaymentService _movieService;
        private readonly ILogger<PaymentController> _logger;
        private readonly ISecurityService _securityService;
       
        public PaymentController(IPaymentService movieService, ILogger<PaymentController> logger, ISecurityService securityService)
        {
            _movieService = movieService;
            _logger = logger;
            _securityService = securityService;
        }


        [HttpGet("", Name = "GetAllPayments")]
        public async Task<List<PaymentDto>> GetAll()
        {
            var result = await _movieService.GetAll();
            return result.Select(x => x.ToPaymentDto()).ToList();
        }

        [HttpGet("{PaymentId}", Name = "GetPayment")]
        public async Task<PaymentDto?> Get(int PaymentId)
        {
            var result = await _movieService.GetById(PaymentId);
            return result?.ToPaymentDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] PaymentDto requestDto)
        {
            var movieModel = requestDto.ToPaymentModel();
            return await _movieService.CreatePayment(movieModel);
        }

        [HttpPut, Route("{PaymentId}")]
        public async Task<IActionResult> Update([FromBody] PaymentDto requestDto)
        {
            requestDto.PaymentID = int.Parse(HttpContext.Request.RouteValues["PaymentId"].ToString());
            await _movieService.UpdatePayment(requestDto.ToPaymentModel());
            return Ok();
        }

        [HttpDelete, Route("{PaymentId}")]
        public async Task<IActionResult> Delete(int PaymentId)
        {
            await _movieService.DeletePayment(PaymentId);
            return Ok();
        }
    }
}
