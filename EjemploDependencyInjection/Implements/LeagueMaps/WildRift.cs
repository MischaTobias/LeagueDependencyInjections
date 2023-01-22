using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements.LeagueMaps;

internal sealed class WildRift : ILeagueMap
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    private readonly IEnumerable<IChampion> _champions;
    public WildRift(IEnumerable<IChampion> champions)
    {
        _champions = champions;
    }

    public void StartGame()
    {
        foreach (var champ in _champions)
        {
            LogService(champ, champ.SayRole());
            champ.StartSpells();
        }
    }

    private static void LogService<T>(T service, string message)
        where T : IReportServiceLifetime =>
        Console.WriteLine(
            $"    {typeof(T).Name}: {service.Id} ({message})");

    public string SayGameStart() => "Bienvenidos a la grieta del invocador.";
}

