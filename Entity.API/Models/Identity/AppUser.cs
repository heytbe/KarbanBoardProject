using Microsoft.AspNetCore.Identity;

namespace Entity.API.Models.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string UserPhoto { get; set; }
    }
}
