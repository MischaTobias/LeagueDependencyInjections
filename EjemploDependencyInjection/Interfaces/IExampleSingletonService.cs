using Microsoft.Extensions.DependencyInjection;

namespace EjemploDependencyInjection.Interfaces;

public interface IExampleSingletonService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;

}