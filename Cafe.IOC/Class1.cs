using Cafe.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.IOC;

public static class CommonIOC
{
    public static void RegisterIOC(this IServiceCollection service, IConfiguration configuration) {
        service.RegisterInfrasutucture(configuration);
    }
}
