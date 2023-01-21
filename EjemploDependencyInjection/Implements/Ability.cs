using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements;

internal sealed class Ability : IExampleSingletonService
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
}
