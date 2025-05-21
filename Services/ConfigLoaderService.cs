using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.IO;
using OPCLibrary.BaseNodeClass;

public class ConfigLoaderService : IConfigLoaderService
{
    private readonly IConfigurationService _configurationService;
    private readonly IAddConfig _configDeserializer;
    private readonly IConfigProcessor _processor;

    public ConfigLoaderService(
        IConfigurationService configurationService,
        IAddConfig configDeserializer,
        IConfigProcessor processor)
    {
        _configurationService = configurationService;
        _configDeserializer = configDeserializer;
        _processor = processor;

        _configurationService.ConfigurationServiceChanged += OnConfigurationChanged;
    }

    public void Start()
    {
        // Можна викликати десеріалізацію при старті
        Console.WriteLine("ConfigLoaderService запущено");
        ReloadAndProcess();
    }

    private void OnConfigurationChanged(object? sender, EventArgs e)
    {
        Console.WriteLine("Зміни в конфігурації виявлені, виконується оновлення...");
        ReloadAndProcess();
    }

    private void ReloadAndProcess()
    {
        var baseNodes = _configDeserializer.LoadBaseNodeConfig();
        var alarms = _configDeserializer.LoadAlarmNodeConfig();

        if (baseNodes != null)
            _processor.ProcessNodes(baseNodes);

        if (alarms != null)
            _processor.ProcessAlarms(alarms);
    }
}