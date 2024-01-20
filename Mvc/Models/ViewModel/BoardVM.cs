using Mvc.Models.Create;
using Mvc.Models.List;

namespace Mvc.Models.ViewModel
{
    public class BoardVM
    {
        public Response<BoardList> list { get; set; }
        public BoardCreate create { get; set; }
    }
}
