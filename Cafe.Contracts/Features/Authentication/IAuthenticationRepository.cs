using Cafe.Domain.Core.Models;
using Cafe.Domain.Features.User;

namespace Cafe.Contracts.Features.Authentication
{

    public interface IAuthenticationRepository
    {
        public Task<AuthenticationResponse> Login(RawaanUser user);

        public Task<RawaanUser?> GetUserByRefreshToken(string RefreshToken);

        public Task<bool> CreateUser(string UserName, string Password, int RoleId);
    }
}