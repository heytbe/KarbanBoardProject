using Core.API.Entity;

namespace Entity.API.Models.Identity
{
    public class UserRefreshToken : EntityBase
    {
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
