using Microsoft.AspNetCore.Mvc;
using Mvc.Client;
using Mvc.Models;
using Mvc.Models.List;

namespace KarbanBoard.Components
{
    public class UserBoardViewComponent : ViewComponent
    {
        private readonly CustomClient _client;

        public UserBoardViewComponent(CustomClient client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _client._client.GetAsync($"api/BoardUser/user-board-list?email={User.Identity.Name}");
            Response<BoardListByUser> response = await result.Content.ReadFromJsonAsync<Response<BoardListByUser>>();
            return View(response);
        }

    }
}
