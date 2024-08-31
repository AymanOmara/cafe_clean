using Cafe.Application.Core;
using Cafe.Infrastructure;
using Cafe.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.IOC;

public static class CommonIOC
{
    public static void RegisterIOC(this IServiceCollection service, IConfiguration configuration) {
        service.RegisterInfrastructure(configuration);
        service.RegisterApplicationIOC();
        service.RegisterSharedIOC();
    }
}