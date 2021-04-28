using Microsoft.Extensions.DependencyInjection;
using System;

namespace UnitMan
{
    public sealed class UnitManager : IUnitManager
    {
        private readonly IServiceProvider _serviceProvider;

        public UnitManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public TUnit Use<TUnit>() where TUnit : IUnit
        {
            var unit = _serviceProvider.GetRequiredService<TUnit>();

            if (unit == null)
            {
                throw new NullReferenceException($"Unit component not found.");
            }

            return unit;
        }
    }

}
