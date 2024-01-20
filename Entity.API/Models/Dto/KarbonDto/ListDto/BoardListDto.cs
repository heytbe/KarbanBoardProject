namespace Entity.API.Models.Dto.KarbonDto.ListDto
{
    public record BoardListDto
    {
        public Guid Id { get; init; }
        public string BoardName { get; init; }
        public string? BoardColor { get; init; }
        public string UserEmail { get; set; }
    }
}
