using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Microsoft.AspNetCore.Mvc;
using Service.API.Service.Abstract;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListCardController : CustomBaseController
    {
        private readonly ITaskListCardService _service;

        public TaskListCardController(ITaskListCardService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("taskcard-create")]
        public async Task<IActionResult> Create([FromForm] TaskListCreateDto createDto, [FromQuery] Guid BoardListId)
        {
            return ActionResult(await _service.CreateAsync(createDto, BoardListId));
        }

        [HttpDelete]
        [Route("card-delete")]
        public async Task<IActionResult> CardDelete([FromQuery] Guid id)
        {
            return ActionResult(await _service.DeleteAsync(true, id));
        }

        [HttpPut]
        [Route("card-update")]
        public async Task<IActionResult> CardUpdate([FromForm] ListCardUpdateDto updateDto, [FromQuery] Guid id)
        {
            return ActionResult(await _service.UpdateAsync(false,updateDto, id));
        }

        [HttpGet]
        [Route("cart-list")]
        public async Task<IActionResult> CardList([FromQuery] Guid id)
        {
            return ActionResult(await _service.GetByIdAsync(false,id));
        }
    }
}
