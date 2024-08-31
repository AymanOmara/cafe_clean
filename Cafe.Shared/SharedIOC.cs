using Cafe.Shared.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Shared
{
	public static class SharedIOC
	{
		public static void RegisterSharedIOC(this IServiceCollection service)
		{
			service.RegisterLocalizationService();
        }
	}
}