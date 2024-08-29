using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Infrastructure
{
	public static class IOC
	{
		public static void RegisterInfrasutucture(this IServiceCollection services, IConfiguration configuration) {
            
            services.AddDbContext<ReadDBContext>(ctx => ctx.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}