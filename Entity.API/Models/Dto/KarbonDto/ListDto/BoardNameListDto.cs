namespace Entity.API.Models.Dto.KarbonDto.ListDto
{
    public record BoardNameListDto
    {
        public string BoardName { get; init; }
        public string? BoardColor { get; init; }
    }
}
