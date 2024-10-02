using System.Reflection;
using Cafe.Application.Core.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Cafe.Application.Core
{
    public static class ApplicationIOC
    {
        public static void RegisterApplicationIOC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            services.AddMediatR(typeof(ApplicationIOC).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}