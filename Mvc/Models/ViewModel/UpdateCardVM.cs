using Mvc.Models.List;
using Mvc.Models.Update;

namespace Mvc.Models.ViewModel
{
    public class UpdateCardVM
    {
        public ResponseOne<CardList> get { get; set; }
        public UpdateCard update { get; set; }
    }
}
