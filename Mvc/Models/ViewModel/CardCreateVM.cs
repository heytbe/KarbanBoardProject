using Mvc.Models.Create;
using Mvc.Models.List;

namespace Mvc.Models.ViewModel
{
    public class CardCreateVM
    {
        public CartCreate create { get; set; }
        public Response<BoardListList> get { get; set; }
    }
}
