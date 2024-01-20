using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Client;
using Mvc.Models;
using Mvc.Models.Create;
using Mvc.Models.List;
using Mvc.Models.Update;
using Mvc.Models.User;
using Mvc.Models.ViewModel;

namespace Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly CustomClient _client;

        public HomeController(CustomClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var request = await _client._client.GetAsync($"api/Board/board-list?PageSize=10&email={User.Identity.Name}");
            Response<BoardList> result = await request.Content.ReadFromJsonAsync<Response<BoardList>>();
            BoardVM board = new BoardVM();
            board.list = result;
            return View(board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] BoardCreate create)
        {
            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(new StringContent(create.BoardName), "boardName");
                formContent.Add(new StringContent(create.BoardColor), "boardColor");
                formContent.Add(new StringContent(create.UserEmail), "userEmail");
                foreach (var item in create.BoardListCreate)
                {
                    formContent.Add(new StringContent(item.ToString()), "boardListCreateDtos");
                }

                if (create.BoardUsersCreate is not null)
                {

                    foreach (var item in create.BoardUsersCreate)
                    {
                        formContent.Add(new StringContent(item), "boardUsersCreateDtos");
                    }
                }

                var movie = await _client._client.PostAsync("api/Board/create-board", formContent);


            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromQuery] Guid itemid)
        {
            var deletemovie = await _client._client.DeleteAsync($"api/Board/delete-board?id={itemid}");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromQuery] Guid itemid)
        {
            var request = await _client._client.GetAsync($"api/Board/board-one-list?id={itemid}");
            ResponseOne<BoardList> result = await request.Content.ReadFromJsonAsync<ResponseOne<BoardList>>();
            BoardUpdateVM updateVM = new BoardUpdateVM();
            updateVM.get = result;
            return View(updateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] BoardUpdate update)
        {
            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(new StringContent(update.BoardName), "boardName");
                formContent.Add(new StringContent(update.BoardColor), "boardColor");

                var movie = await _client._client.PutAsync($"api/Board/update-board?id={update.Id}", formContent);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SingOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public async Task<JsonResult> GetOneUser([FromQuery] string userName)
        {
            var request = await _client._client.GetAsync($"api/User/get-user?username={userName}");
            ResponseOne<AppUserDto> result = await request.Content.ReadFromJsonAsync<ResponseOne<AppUserDto>>();

            return new JsonResult(result);
        }
    }
}