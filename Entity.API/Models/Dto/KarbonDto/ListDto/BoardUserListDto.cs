using Entity.API.Models.KarbanModels;

namespace Entity.API.Models.Dto.KarbonDto.ListDto
{
    public record BoardUserListDto
    {
        public Guid? BoardId { get; init; }
        public BoardNameListDto Board { get; init; }
        public string UserEmail { get; init; }
    }
}
