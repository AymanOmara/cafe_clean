using Cafe.Contracts.Features.Authentication;
using Cafe.Domain.Core.Models;
using Cafe.Domain.Features.User;
using Cafe.Infrastructure.Common.Authentication;
using Cafe.Shared.Localization;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Infrastructure.Repositories
{
	public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly IJWTGenerator _jwtGenerator;
        private readonly RawaanDBContext _context;
        public readonly UserManager<RawaanUser> _userManager;
        
        public AuthenticationRepository(RawaanDBContext context, IJWTGenerator jwtGenerator, UserManager<RawaanUser> userManager, LanguageService languageService)
		{
            _jwtGenerator = jwtGenerator;
            _context = context;
            _userManager = userManager;
        }

        public async Task<AuthenticationResponse> Login(RawaanUser user)
        {
            var token = await _jwtGenerator.GenerateToken(user);
            var refreshToken = _jwtGenerator.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            await _userManager.UpdateAsync(user);
            return new AuthenticationResponse(Token: token, RefreshToken: refreshToken);
        }
    }
}