using Mvc.Models.List;
using Mvc.Models.Update;

namespace Mvc.Models.ViewModel
{
    public class BoardUpdateVM
    {
        public ResponseOne<BoardList> get { get; set; }
        public BoardUpdate update { get; set; }
    }
}
