using Microsoft.AspNetCore.Mvc;
using Service.API.Service.Abstract;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : CustomBaseController
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }


        [HttpDelete]
        [Route("ticket-delete")]
        public async Task<IActionResult> Index([FromQuery] Guid id)
        {
            return ActionResult(await _service.DeleteAsync(false, id));
        }
    }
}
