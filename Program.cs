using NetLogger;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<IMyLogger,MyLogger>();
    })
    .Build();

await host.RunAsync();
