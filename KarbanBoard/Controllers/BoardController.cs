using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.RequestFeature.EntityParameters;
using Microsoft.AspNetCore.Mvc;
using Service.API.Service.Abstract;
using System.Text.Json;

namespace KarbanBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : CustomBaseController
    {
        private readonly IBoardService _service;

        public BoardController(IBoardService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create-board")]
        public async Task<IActionResult> CreateBoard([FromForm] BoardCreateDto createDto)
        {
            return ActionResult(await _service.CreateAsync(createDto));
        }

        [HttpDelete]
        [Route("delete-board")]
        public async Task<IActionResult> DeleteBoard([FromQuery] Guid id)
        {
            return ActionResult(await _service.DeleteAsync(false, id));
        }

        [HttpGet]
        [Route("board-list")]
        public async Task<IActionResult> List([FromQuery] BoardParameters boardParameters, [FromQuery] string email)
        {
            var board = await _service.GetAllListAsync(false,email, boardParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(board.metaData));
            return ActionResult(board.responseDto);
        }

        [HttpPut]
        [Route("update-board")]
        public async Task<IActionResult> Update([FromForm] BoardUpdateDto updateDto, [FromQuery] Guid id)
        {
            return ActionResult(await _service.UpdateAsync(false,id,updateDto));
        }

        [HttpGet]
        [Route("board-one-list")]
        public async Task<IActionResult> GetOneBoard([FromQuery] Guid id)
        {
            return ActionResult(await _service.GetOneByIdAsync(false, id));
        }
    }
}
