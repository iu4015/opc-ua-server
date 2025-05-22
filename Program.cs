using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OPCLibrary.BaseNodeClass;
using OPCLibrary.NodeManager;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<INodeManager, NodeManager>(); // Реєстрація NodeManager
        services.AddSingleton<RealTimeNodeService>(); // Реєстрація RealTimeNodeService
    })
    .Build();

var realTimeNodeService = host.Services.GetRequiredService<RealTimeNodeService>();
await realTimeNodeService.StartAsync("broker.hivemq.com", "test/topic"); // Виклик StartAsync з брокером і топіком

await host.RunAsync();
