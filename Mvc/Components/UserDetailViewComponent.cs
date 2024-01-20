using Microsoft.AspNetCore.Mvc;
using Mvc.Client;
using Mvc.Models;
using Mvc.Models.User;

namespace Mvc.Components
{
    public class UserDetailViewComponent : ViewComponent
    {
        private readonly CustomClient _client;

        public UserDetailViewComponent(CustomClient client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _client._client.GetAsync($"api/User/get-user-email?email={User.Identity.Name}");
            ResponseOne<AppUserDto> response = await result.Content.ReadFromJsonAsync<ResponseOne<AppUserDto>>();
            return View(response);
        }
    }
}
