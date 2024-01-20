using Microsoft.AspNetCore.Http;

namespace Entity.API.Models.Dto.KarbonDto.CreateDto
{
    public record TaskListCreateDto
    {
        public string? CardName { get; init; }
        public string? CardColor { get; init; }
        public string Description { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? FinisDate { get; init; }
        public List<string>? ListTicketCreateDtos { get; set; }
        public List<IFormFile>? ListAddition { get; set; }
    }
}
