using Microsoft.AspNetCore.Identity;

namespace Cafe.Domain.Features.User
{
	public class RawaanUser : IdentityUser
    {
        public string RefreshToken { get; set; } = string.Empty;

    }
}