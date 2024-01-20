namespace Entity.API.Models.Dto.KarbonDto.UpdateDto
{
    public class BoardUpdateDto
    {
        public string BoardName { get; set; }
        public string? BoardColor { get; set; }
        public List<string>? BoardUsersUpdate { get; set; }
    }
}
