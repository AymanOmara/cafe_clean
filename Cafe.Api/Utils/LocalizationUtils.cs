using System.Reflection;
using Microsoft.Extensions.Options;
using static Cafe.Shared.Localization.LanguageService;

namespace Cafe.Api.Utils
{
    public static class LocalizationUtils
    {
        public static void SetUpLocalization(this IServiceCollection services)
        {
                services
                .AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create(nameof(SharedResource), assemblyName.Name);
                    };
                });
        }
        public static void ConfigureRequestLocalization(this IApplicationBuilder app)
        {
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions.Value);
        }
    }
}