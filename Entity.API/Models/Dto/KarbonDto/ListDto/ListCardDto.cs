namespace Entity.API.Models.Dto.KarbonDto.ListDto
{
    public record ListCardDto
    {
        public Guid Id { get; set; }
        public string? CardName { get; init; }
        public string? CardColor { get; init; }
        public string Description { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? FinisDate { get; init; }

        public virtual IEnumerable<ListTicketDto> ListTickets { get; set; }
        public virtual IEnumerable<ListAdditionDto> ListAdditions { get; set; }
    }
}
