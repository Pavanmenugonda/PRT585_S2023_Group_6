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
    public class UserController : BaseController
    {

        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly ISecurityService _securityService;
       
        public UserController(IUserService userService, ILogger<UserController> logger, ISecurityService securityService)
        {
            _userService = userService;
            _logger = logger;
            _securityService = securityService;
        }

        [HttpGet("", Name = "GetAllUsers")]
        public async Task<List<UserDto>> GetAll()
        {
            var result = await _userService.GetAll();
            return result.Select(x => x.ToUserDto()).ToList();
        }

        [HttpGet("{UserId}", Name = "GetUser")]
        public async Task<UserDto?> Get(int UserId)
        {
            var result = await _userService.GetById(UserId);
            return result?.ToUserDto();
        }

        [HttpPost, Route("")]
        public async Task<int> Create([FromBody] UserDto requestDto)
        {
            var UserModel = requestDto.ToUserModel();
            return await _userService.CreateUser(UserModel);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] UserDto requestDto)
        {
            await _userService.UpdateUser(requestDto.ToUserModel());
            return Ok();
        }

        [HttpDelete, Route("{UserId}")]
        public async Task<IActionResult> Delete(int UserId)
        {
            await _userService.DeleteUser(UserId);
            return Ok();
        }
    }
}
