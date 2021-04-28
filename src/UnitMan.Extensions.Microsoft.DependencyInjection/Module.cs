using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Linq;

namespace UnitMan.Extensions.Microsoft.DependencyInjection
{
    public static class Module
    {
        public static IServiceCollection AddUnitManager(this IServiceCollection services)
        {
            services.TryAddSingleton(typeof(IUnitManager), typeof(UnitManager));

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            .Where(x => typeof(IUnit).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var type in types)
            {
                services.TryAddSingleton(type);
            }

            return services;
        }
    }
}
