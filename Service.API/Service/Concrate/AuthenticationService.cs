using Core.API.Response;
using Data.API.Repositories;
using Data.API.UnitOfWork;
using Entity.API.Models.Dto.Token;
using Entity.API.Models.Dto.User;
using Entity.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Services.API.Service.Abstract;

namespace Services.API.Service.Cocrate
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _manager;
        private readonly IUnitOfWorkRepo _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _repository;
        public AuthenticationService(ITokenService tokenService,UserManager<AppUser> userManager,IUnitOfWorkRepo unitOfWork,IGenericRepository<UserRefreshToken> repository)
        {
            _manager = userManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseDto<TokenDto>> CreateToken(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
            var user = await _manager.FindByEmailAsync(loginDto.Email);
            if(user == null)
            {
                return ResponseDto<TokenDto>.Fail("Email veya Şifre Yanlış", 400,true);
            }

            if((await _manager.CheckPasswordAsync(user,loginDto.Password)) == false)
            {
                return ResponseDto<TokenDto>.Fail("Email veya Şifre Yanlış", 400, true);
            }

            var userToken = _tokenService.CreateToken(user);
            var refreshToken = await _repository.GetOne(false,x => x.UserId == user.Id);
            if(refreshToken == null)
            {
                await _repository.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    RefreshToken = userToken.RefreshToken,
                    RefreshTokenExpiration = userToken.RefreshTokenExpiration
                });
            }
            else
            {
                refreshToken.RefreshToken = userToken.RefreshToken;
                refreshToken.RefreshTokenExpiration = userToken.RefreshTokenExpiration;
            }

            await _unitOfWork.SaveAsync();

            return ResponseDto<TokenDto>.Success(userToken, 200);

        }
    }
}
