using Cafe.Domain.Features.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Infrastructure
{
	public class RawaanDBContext : IdentityDbContext<RawaanUser>
    {
        public RawaanDBContext(DbContextOptions<RawaanDBContext> options) : base(options)
        {

        }
    }
}