using Core.API.Entity;

namespace Entity.API.Models.KarbanModels
{
    public class BoardLists : EntityBase
    {
        public BoardLists()
        {
            ListCards = new HashSet<ListCard>();
        }

        public string ListName { get; set; }
        public Guid BoardId { get; set; }
        public virtual Board Board{ get; set; }

        public virtual ICollection<ListCard> ListCards { get; set; }
    }
}
