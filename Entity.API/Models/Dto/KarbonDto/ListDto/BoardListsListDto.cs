namespace Entity.API.Models.Dto.KarbonDto.ListDto
{
    public record BoardListsListDto
    {
        public Guid Id { get; init; }
        public string ListName { get; init; }

        public IEnumerable<ListCardDto> ListCards { get; set; }
    }
}
