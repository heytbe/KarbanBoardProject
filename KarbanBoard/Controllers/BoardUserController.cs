using Microsoft.AspNetCore.Mvc;
using Service.API.Service.Abstract;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardUserController : CustomBaseController
    {
        private readonly IBoardUserService _service;

        public BoardUserController(IBoardUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("user-board-list")]
        public async Task<IActionResult> BoardList([FromQuery] string email)
        {
            return ActionResult(await _service.BoardUserListAsync(false, email));
        }
    }
}
