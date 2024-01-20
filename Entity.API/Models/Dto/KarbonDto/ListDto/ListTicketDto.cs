namespace Entity.API.Models.Dto.KarbonDto.ListDto
{
    public record ListTicketDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}
