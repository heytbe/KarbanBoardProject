namespace Entity.API.Models.Dto.KarbonDto.CreateDto
{
    public record BoardCreateDto
    {
        public string BoardName { get; init; }
        public string? BoardColor { get; init; }
        public string UserEmail { get; init; }
        public List<string> BoardListCreateDtos { get; set; }
        public List<string>? BoardUsersCreateDtos { get; set; }
    }
}
