using Entity.API.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Services.API.Service.Abstract;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToke(LoginDto login)
        {
            return Ok(await _service.CreateToken(login));
        }
    }
}
