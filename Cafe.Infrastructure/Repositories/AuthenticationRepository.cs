using Cafe.Contracts.Features.Authentication;
using Cafe.Domain.Core.Models;
using Cafe.Domain.Features.User;
using Cafe.Infrastructure.Common.Authentication;
using Cafe.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IJWTGenerator _jwtGenerator;

        private readonly UserManager<RawaanUser> _userManager;

        private readonly RawaanDBContext _context;

        public AuthenticationRepository(IJWTGenerator jwtGenerator, UserManager<RawaanUser> userManager, RawaanDBContext context)
        {
            _jwtGenerator = jwtGenerator;
            _userManager = userManager;
            _context = context;
        }

        public async Task<AuthenticationResponse> Login(RawaanUser user)
        {
            var token = await _jwtGenerator.GenerateToken(user);
            var refreshToken = _jwtGenerator.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            await _userManager.UpdateAsync(user);
            return new AuthenticationResponse(
                Token: token,
                RefreshToken: refreshToken
                );
        }

        public async Task<RawaanUser?> GetUserByRefreshToken(string RefreshToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(usr => usr.RefreshToken == RefreshToken);
            return user;
        }

        public async Task<bool> CreateUser(string UserName, string Password, int RoleId)
        {
            RawaanUser user = new()
            {
                UserName = UserName,
            };
            await _userManager.CreateAsync(user, password: Password);
            var roleName = Enum.GetName(typeof(CafeRoles), RoleId);
            await _userManager.AddToRoleAsync(user, roleName ?? "");
            return true;
        }
    }
}