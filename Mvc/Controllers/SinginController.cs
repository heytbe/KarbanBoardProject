using Microsoft.AspNetCore.Mvc;
using Mvc.Client;
using Mvc.Models.Create;

namespace Mvc.Controllers
{
    public class SinginController : Controller
    {
        private readonly CustomClient _client;

        public SinginController(CustomClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CreateUser create)
        {
            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(new StringContent(create.Email), "email");
                formContent.Add(new StringContent(create.Password), "password");
                formContent.Add(new StringContent(create.UserName), "userName");

                formContent.Add(new StreamContent(create.Photo.OpenReadStream()), "photo", Path.GetFileName(create.Photo.FileName));


                var user = await _client._client.PostAsync("api/User", formContent);

                if (user.IsSuccessStatusCode)
                {
                    ViewBag.Ok = "Kaydedildi";
                }
              
            }

            return RedirectToAction("Index");

        }
    }
}
