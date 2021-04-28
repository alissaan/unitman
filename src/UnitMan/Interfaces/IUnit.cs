using System.Threading;
using System.Threading.Tasks;

namespace UnitMan
{
    public interface IUnit
    {

    }

    public interface IUnit<TInput> : IUnit
    {
        Task ExecuteAsync(TInput input, CancellationToken cancellationToken = default);
    }

    public interface IUnit<TInput, TOutput> : IUnit
    {
        Task<TOutput> ExecuteAsync(TInput input, CancellationToken cancellationToken = default);
}
}
