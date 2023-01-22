using EjemploDependencyInjection.Implements;
using EjemploDependencyInjection.Implements.Champions;
using EjemploDependencyInjection.Implements.LeagueMaps;
using EjemploDependencyInjection.Implements.SummonerSpells;
using EjemploDependencyInjection.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<ILeagueMap, WildRift>();
        services.AddScoped<IChampion, MidLaner>();
        services.AddScoped<IChampion, TopLaner>();
        services.AddSingleton<ISummonerSpell, Flash>();
        services.AddSingleton<ISummonerSpell, Ignite>();
        services.AddTransient<ServiceLifetimeReporter>();
    })
    .Build();

ExemplifyServiceLifetime(host.Services, "Lifetime 1");
ExemplifyServiceLifetime(host.Services, "Lifetime 2");

await host.RunAsync();

static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"{lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeLogger>()");

    Console.WriteLine("...");

    logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"{lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeLogger>()");

    Console.WriteLine();
}