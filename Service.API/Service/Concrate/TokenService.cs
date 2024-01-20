using Entity.API.Models.Dto.Token;
using Entity.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.API.Service.Abstract;
using Services.API.SignService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Services.API.Service.Cocrate
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CustomTokenOptions _customTokenOptions;
        public TokenService(UserManager<AppUser> userManager,IOptions<CustomTokenOptions> options)
        {
            _userManager = userManager;
            _customTokenOptions = options.Value;
        }

        private string CreateRefreshToken()
        {
            var createbyte = new Byte[32];
            using var ramdom = RandomNumberGenerator.Create();
            ramdom.GetBytes(createbyte);
            return Convert.ToBase64String(createbyte);
        }

        private IEnumerable<Claim> CreateJwtPayloadToken(AppUser userApp,List<string> audiences)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userApp.Id)),
                new Claim(JwtRegisteredClaimNames.Email,userApp.Email),
                new Claim(ClaimTypes.Name,userApp.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return claims;
        }

        public TokenDto CreateToken(AppUser userApp)
        {
            var accestokenexpiration = DateTime.Now.AddMinutes(_customTokenOptions.AccessTokenExpiration);
            var refreshtokenexpiration = DateTime.Now.AddMinutes(_customTokenOptions.RefreshTokenExpiration);
            var securitykey = SimetricSecurity.SymmetricKey(_customTokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                    issuer : _customTokenOptions.Issuer,
                    expires : accestokenexpiration,
                    notBefore : DateTime.Now,
                    claims : CreateJwtPayloadToken(userApp,_customTokenOptions.Audience),
                    signingCredentials : signingCredentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                AccessTokenExpiration = accestokenexpiration,
                RefreshToken = CreateRefreshToken(),
                RefreshTokenExpiration = refreshtokenexpiration
            };

            return tokenDto;
        }
    }
}
