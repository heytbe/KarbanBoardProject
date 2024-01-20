namespace Mvc.Models.Create
{
    public class CartCreate
    {
        public string? CardName { get; set; }
        public string? CardColor { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinisDate { get; set; }
        public List<string>? ListTicketCreateDtos { get; set; }
        public List<IFormFile>? ListAddition { get; set; }
    }
}
