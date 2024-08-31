using Cafe.Domain.Features.User;
namespace Cafe.Infrastructure.Common.Authentication
{
    public interface IJWTGenerator
	{
        public Task<string> GenerateToken(RawaanUser user);
        public string GenerateRefreshToken();
    }
}

