using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements;
internal sealed class Champion : IExampleScopedService
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    private readonly IExampleSingletonService _singletonService;

    public Champion(IExampleSingletonService singletonService)
    {
        _singletonService = singletonService;
    }

    public void ReportLifetime()
    {
        LogService(_singletonService, "Always the same");
    }

    private static void LogService<T>(T service, string message)
        where T : IReportServiceLifetime =>
        Console.WriteLine(
            $"    {typeof(T).Name}: {service.Id} ({message})");
}