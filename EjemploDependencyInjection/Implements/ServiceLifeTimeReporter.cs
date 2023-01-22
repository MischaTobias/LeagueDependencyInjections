using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements;

internal sealed class ServiceLifetimeReporter
{
    private readonly ILeagueMap _leagueMap;

    public ServiceLifetimeReporter(ILeagueMap transientService) => _leagueMap = transientService;

    public void ReportServiceLifetimeDetails(string lifetimeDetails)
    {
        Console.WriteLine(lifetimeDetails);

        LogService(_leagueMap, _leagueMap.SayGameStart());
        _leagueMap.StartGame();
    }

    private static void LogService<T>(T service, string message)
        where T : IReportServiceLifetime =>
        Console.WriteLine(
            $"    {typeof(T).Name}: {service.Id} ({message})");
}
