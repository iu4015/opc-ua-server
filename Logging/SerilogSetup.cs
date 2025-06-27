using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace OpcUaServer.Logging
{
    // Налаштування Serilog для логування OPC UA сервера
    public static class SerilogSetup
    {
        // Базова конфігурація логера
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(
                    path: "logs/opc-ua-.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Properties:j}{NewLine}{Exception}")
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        // Додає сервіси логування до DI контейнера
        public static IServiceCollection AddOpcUaLogging(this IServiceCollection services)
        {
            ConfigureLogging();
            services.AddSingleton(Log.Logger);
            services.AddHostedService<NodeLoggingService>();
            return services;
        }
    }
}
