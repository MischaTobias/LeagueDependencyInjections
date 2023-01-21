using EjemploDependencyInjection.Interfaces;

namespace EjemploDependencyInjection.Implements;

internal sealed class ServiceLifetimeReporter
{
    private readonly IExampleTransientService _transientService;

    public ServiceLifetimeReporter(IExampleTransientService transientService) =>
        _transientService = transientService;

    public void ReportServiceLifetimeDetails(string lifetimeDetails)
    {
        Console.WriteLine(lifetimeDetails);

        //LogService(_transientService, "Always different");
        //LogService(_scopedService, "Changes only with lifetime");
        LogService(_transientService, "Always different");
        _transientService.ReportLifetime();
    }

    private static void LogService<T>(T service, string message)
        where T : IReportServiceLifetime =>
        Console.WriteLine(
            $"    {typeof(T).Name}: {service.Id} ({message})");
}
