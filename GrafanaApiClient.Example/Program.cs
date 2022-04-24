using GrafanaApiClient;
using GrafanaApiClient.Example;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddTransient<IGrafanaControlService, GrafanaControlService>();

        services.AddHttpClient();
    })
    .Build();

await host.RunAsync();
