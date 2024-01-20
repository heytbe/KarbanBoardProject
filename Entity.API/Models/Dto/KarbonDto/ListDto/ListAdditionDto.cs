namespace Entity.API.Models.Dto.KarbonDto.ListDto
{
    public record ListAdditionDto
    {
        public Guid Id { get; set; }
        public string? Name { get; init; }
        public string Path { get; init; }
    }
}
