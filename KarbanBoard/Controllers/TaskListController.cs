using Microsoft.AspNetCore.Mvc;
using Service.API.Service.Abstract;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : CustomBaseController
    {
        private readonly ITaskListService _service;

        public TaskListController(ITaskListService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List([FromQuery] Guid id)
        {
            return ActionResult(await _service.GetAllTaskListByBoardAsync(false, id));
        }
    }
}
