using Microsoft.AspNetCore.Http;

namespace Entity.API.Models.Dto.KarbonDto.UpdateDto
{
    public record ListCardUpdateDto
    {
        public string? CardName { get; init; }
        public string? CardColor { get; init; }
        public string Description { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? FinisDate { get; init; }
        public List<string>? ListTicket { get; set; }
        public List<IFormFile>? ListAddition { get; set; }
    }
}
