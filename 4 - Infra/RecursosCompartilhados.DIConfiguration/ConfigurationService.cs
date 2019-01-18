using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RecursosCompartilhados.DIConfiguration
{
    public static class ConfigurationService
    {
        private static IConfigurationRoot _configuration;

        public static void Builder(IConfigurationRoot configuration, IServiceCollection serviceCollection)
        {
            _configuration = configuration;
        }

        public static T GetOptions<T>() where T : class, new()
        {
            var optionClass = new T();
            _configuration.GetSection(typeof(T).Name).Bind(optionClass);
            return optionClass;
        }
    }
}
