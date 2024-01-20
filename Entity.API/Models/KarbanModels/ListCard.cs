using Core.API.Entity;

namespace Entity.API.Models.KarbanModels
{
    public class ListCard : EntityBase
    {
        public ListCard()
        {
            ListTickets = new HashSet<ListTicket>();
            ListAdditions = new HashSet<ListAddition>();
        }

        public string? CardName { get; set; }
        public string? CardColor { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinisDate { get; set; }

        public Guid BoardListsId { get; set; }
        public virtual BoardLists BoardLists { get; set; }
        public virtual ICollection<ListTicket> ListTickets { get; set; }
        public virtual ICollection<ListAddition> ListAdditions { get; set; }
    }
}
