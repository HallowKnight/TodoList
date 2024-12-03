using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Business.Application.StringLocalizer;

public static class LocalizationServiceExtensions
{
    public static IServiceCollection AddLocalizationFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        services.AddLocalization();
        IEnumerable<Type> resourceTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Resource"));

        foreach (Type resourceType in resourceTypes)
        {
            Type localizerType = typeof(IStringLocalizer<>).MakeGenericType(resourceType);
            services.AddTransient(localizerType, serviceProvider =>
            {
                IStringLocalizerFactory factory = serviceProvider.GetRequiredService<IStringLocalizerFactory>();
                return factory.Create(resourceType);
            });
        }

        return services;
    }
}