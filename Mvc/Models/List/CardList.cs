namespace Mvc.Models.List
{
    public class CardList
    {
        public Guid Id { get; set; }
        public string? CardName { get; set; }
        public string? CardColor { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinisDate { get; set; }

        public virtual IEnumerable<CardTicketList> ListTickets { get; set; }
        public virtual IEnumerable<CardAdditionList> ListAdditions { get; set; }
    }
}
