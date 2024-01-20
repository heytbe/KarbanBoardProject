using Microsoft.AspNetCore.Http;

namespace Entity.API.Models.Dto.User
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile Photo { get; set; }
    }
}
