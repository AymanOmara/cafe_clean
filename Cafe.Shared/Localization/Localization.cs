using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Cafe.Shared.Localization
{
    public class LanguageService
    {
        public class SharedResource
        {

        }
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName ?? "");
            _localizer = factory.Create(nameof(SharedResource), assemblyName.Name ?? "");
        }

        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}