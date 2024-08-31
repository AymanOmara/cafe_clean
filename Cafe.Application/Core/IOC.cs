using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Cafe.Application.Core
{
    public static class ApplicationIOC
    {
        public static void RegisterApplicationIOC(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationIOC).Assembly);
        }
    }
}