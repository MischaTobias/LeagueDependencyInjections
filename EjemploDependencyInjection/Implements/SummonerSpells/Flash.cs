using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements.SummonerSpells;

internal sealed class Flash : ISummonerSpell
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();

    public string SayName() => "Se ha lanzado un flash.";
}
