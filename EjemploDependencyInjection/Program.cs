﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EjemploDependencyInjection.Implements;
using EjemploDependencyInjection.Interfaces;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IExampleTransientService, WildRift>();
        services.AddScoped<IExampleScopedService, Champion>();
        services.AddSingleton<IExampleSingletonService, Ability>();
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