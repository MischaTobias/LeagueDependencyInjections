using Microsoft.Extensions.DependencyInjection;

namespace EjemploDependencyInjection.Interfaces;

public interface IChampion : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    void StartSpells();
    string SayRole();

}