namespace Mvc.Models.Update
{
    public class UpdateCard
    {
        public Guid itemId { get; set; }
        public string? CardName { get; set; }
        public string? CardColor { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinisDate { get; set; }
        public List<string>? ListTicket { get; set; }
        public List<IFormFile>? ListAddition { get; set; }
    }
}
