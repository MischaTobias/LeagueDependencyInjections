using Microsoft.Extensions.DependencyInjection;

namespace EjemploDependencyInjection.Interfaces;

public interface ILeagueMap : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    void StartGame();

    string SayGameStart();

}
