using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements.Champions;
internal sealed class MidLaner : IChampion
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    private readonly IEnumerable<ISummonerSpell> _summonerSpells;

    public MidLaner(IEnumerable<ISummonerSpell> summonerSpells)
    {
        _summonerSpells = summonerSpells;
    }

    public void StartSpells()
    {
        foreach (var spell in _summonerSpells)
        {
            LogService(spell, spell.SayName());
        }
    }

    private static void LogService<T>(T service, string message)
        where T : IReportServiceLifetime =>
        Console.WriteLine(
            $"    {typeof(T).Name}: {service.Id} ({message})");

    public string SayRole() => "Nuevo MidLaner.";
}