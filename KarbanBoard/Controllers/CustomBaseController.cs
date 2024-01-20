using Core.API.Response;
using Microsoft.AspNetCore.Mvc;

namespace KarbanBoard.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResult<T>(ResponseDto<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
