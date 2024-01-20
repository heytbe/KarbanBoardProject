using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Client;
using Mvc.Models;
using Mvc.Models.Create;
using Mvc.Models.List;
using Mvc.Models.Update;
using Mvc.Models.ViewModel;

namespace Mvc.Controllers
{
    [Authorize]
    public class TaskListController : Controller
    {
        private readonly CustomClient _client;

        public TaskListController(CustomClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index([FromQuery] Guid itemid)
        {
            var request = await _client._client.GetAsync($"api/TaskList/list?id={itemid}");
            Response<BoardListList> response = await request.Content.ReadFromJsonAsync<Response<BoardListList>>();
            CardCreateVM card = new CardCreateVM();
            card.get = response;
            return View(card);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CartCreate create, [FromQuery] Guid itemid)
        {
            //api/TaskListCard/taskcard-create?BoardListId=770d6396-ed86-453e-b8d4-33adf9b43359

            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(new StringContent(create.CardName), "cardName");
                formContent.Add(new StringContent(create.CardColor), "cardColor");
                formContent.Add(new StringContent(create.Description), "description");
                formContent.Add(new StringContent(create.StartDate.ToString()), "startDate");
                formContent.Add(new StringContent(create.FinisDate.ToString()), "finisDate");

                foreach (var item in create.ListTicketCreateDtos)
                {
                    formContent.Add(new StringContent(item), "listTicketCreateDtos");
                }

                foreach (var item in create.ListAddition)
                {
                    formContent.Add(new StreamContent(item.OpenReadStream()), "listAddition", Path.GetFileName(item.FileName));
                }

                var movie = await _client._client.PostAsync($"api/TaskListCard/taskcard-create?BoardListId={itemid}", formContent);
            }


            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Delete([FromQuery] Guid itemid)
        {
            var deletemovie = await _client._client.DeleteAsync($"api/TaskListCard/card-delete?id={itemid}");
            if (deletemovie.IsSuccessStatusCode)
            {
                return new JsonResult("Silindi");
            }


            return new JsonResult("Silinemedi");
        }

        public async Task<JsonResult> List([FromQuery] Guid itemid)
        {
            var request = await _client._client.GetAsync($"api/TaskListCard/cart-list?id={itemid}");
            ResponseOne<CardList> response = await request.Content.ReadFromJsonAsync<ResponseOne<CardList>>();
            return new JsonResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromQuery] Guid itemid)
        {
            var request = await _client._client.GetAsync($"api/TaskListCard/cart-list?id={itemid}");
            ResponseOne<CardList> response = await request.Content.ReadFromJsonAsync<ResponseOne<CardList>>();
            UpdateCardVM update = new UpdateCardVM();
            update.get = response;
            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UpdateCard update, [FromQuery] Guid itemid)
        {
            using (var formContent = new MultipartFormDataContent())
            {
                formContent.Add(new StringContent(update.CardName), "cardName");
                formContent.Add(new StringContent(update.CardColor), "cardColor");
                formContent.Add(new StringContent(update.Description), "description");
                formContent.Add(new StringContent(update.StartDate.ToString()), "startDate");
                formContent.Add(new StringContent(update.FinisDate.ToString()), "finisDate");

                if (update.ListTicket is not null)
                {
                    foreach (var item in update.ListTicket)
                    {
                        formContent.Add(new StringContent(item), "listTicket");
                    }
                }

                if (update.ListAddition is not null)
                {
                    foreach (var item in update.ListAddition)
                    {
                        formContent.Add(new StreamContent(item.OpenReadStream()), "listAddition", Path.GetFileName(item.FileName));
                    }
                }

                var movie = await _client._client.PutAsync($"api/TaskListCard/card-update?id={itemid}", formContent);
            }

            return RedirectToAction("Index");
        }

        public async Task<JsonResult> TicketDelete([FromQuery] Guid itemid) 
        {
            var deletemovie = await _client._client.DeleteAsync($"api/Ticket/ticket-delete?id={itemid}");
            if (deletemovie.IsSuccessStatusCode)
            {
                return new JsonResult("Etiket Silindi");
            }


            return new JsonResult("Etiket Silinemedi");
        }

        public async Task<JsonResult> AdditionDelete([FromQuery] Guid itemid)
        {
            var deletemovie = await _client._client.DeleteAsync($"api/Addition/addition-delete?id={itemid}");
            if (deletemovie.IsSuccessStatusCode)
            {
                return new JsonResult("Dosya Silindi");
            }


            return new JsonResult("Dosya Silinemedi");
        }
    }
}
