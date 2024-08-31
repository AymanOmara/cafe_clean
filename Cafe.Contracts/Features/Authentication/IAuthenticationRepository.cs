using Cafe.Domain.Core.Models;
using Cafe.Domain.Features.User;

namespace Cafe.Contracts.Features.Authentication
{

    public interface IAuthenticationRepository
    {
        public Task<AuthenticationResponse> Login(RawaanUser user);
    }
}