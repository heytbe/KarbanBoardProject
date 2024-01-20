using Microsoft.AspNetCore.Mvc;
using Service.API.Service.Abstract;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionController : CustomBaseController
    {
        private readonly IAdditionService _service;

        public AdditionController(IAdditionService service)
        {
            _service = service;
        }

        [HttpDelete]
        [Route("addition-delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return ActionResult(await _service.DeleteAsync(false,id));
        }
    }
}
