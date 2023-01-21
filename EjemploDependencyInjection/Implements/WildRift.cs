using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements;

internal sealed class WildRift : IExampleTransientService
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
	private readonly IExampleScopedService _scopedService;
	public WildRift(IExampleScopedService scopedService)
	{
        _scopedService = scopedService;
	}

    public void ReportLifetime()
    {
        LogService(_scopedService, "Changes only with lifetime");
        _scopedService.ReportLifetime();
    }

    private static void LogService<T>(T service, string message)
        where T : IReportServiceLifetime =>
        Console.WriteLine(
            $"    {typeof(T).Name}: {service.Id} ({message})");
}

