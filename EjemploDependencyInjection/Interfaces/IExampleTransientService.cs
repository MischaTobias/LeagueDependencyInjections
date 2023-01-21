using Microsoft.Extensions.DependencyInjection;

namespace EjemploDependencyInjection.Interfaces;

public interface IExampleTransientService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    void ReportLifetime();

}
