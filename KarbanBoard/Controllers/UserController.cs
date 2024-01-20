using Entity.API.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Services.API.Service.Abstract;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserDto createUserDto)
        {
            return ActionResult(await _service.CreateUser(createUserDto));
        }

        [HttpGet]
        [Route("get-user")]
        public async Task<IActionResult> GetUser([FromQuery] string username)
        {
            return ActionResult(await _service.GetUsers(username));
        }

        [HttpGet]
        [Route("get-user-email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            return ActionResult(await _service.GetUsersByEmail(email));
        }
    }
}
