using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Mvc.Client;
using Mvc.Models;
using System.Security.Claims;
using Mvc.Models.User;

namespace Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly CustomClient _client;

        public LoginController(CustomClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var client = await _client._client.PostAsJsonAsync<LoginDto>("api/Authentication", loginDto);
            var response = await client.Content.ReadFromJsonAsync<ResponseOne<TokenDto>>();
            if (response.data.AccessToken != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name ,loginDto.Email)
                };
                var claimidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimidentity), authProperties);

                HttpContext.Session.SetString("token", response.data.AccessToken);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
