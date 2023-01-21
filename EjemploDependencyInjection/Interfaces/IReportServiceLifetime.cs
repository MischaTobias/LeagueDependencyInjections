using Microsoft.Extensions.DependencyInjection;

namespace EjemploDependencyInjection.Interfaces;

public interface IReportServiceLifetime
{
    Guid Id { get; }
    ServiceLifetime Lifetime { get; }
}