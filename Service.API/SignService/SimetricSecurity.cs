using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Services.API.SignService
{
    public static class SimetricSecurity
    {
        public static SecurityKey SymmetricKey(string securitykey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
        }
    }
}
