using Microsoft.Extensions.DependencyInjection;

namespace EjemploDependencyInjection.Interfaces;

public interface ISummonerSpell : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;

    string SayName();
}