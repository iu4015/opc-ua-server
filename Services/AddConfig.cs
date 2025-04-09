using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Options;



public class AddConfig : IAddConfig
{
    private readonly NodeConfigPaths _config;

    public AddConfig(IOptions<NodeConfigPaths> config)
    {
        _config = config.Value;
    }

    public async Task<IEnumerable<BaseNode>> LoadBaseNodeConfig()
    {
        try
        {
            if (!File.Exists(_config.BaseNodePath))
            {
                Console.WriteLine("Конфігурація основних вузлів відсутня");
                return Enumerable.Empty<BaseNode>();
            }

            string json = await File.ReadAllTextAsync(_config.BaseNodePath);
            var result = JsonSerializer.Deserialize<List<BaseNode>>(json);
            if (result == null)
            {
                return Enumerable.Empty<BaseNode>();
            }
            return result.AsEnumerable();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка считування конфігу основних вузлів: {ex.Message}");
            return Enumerable.Empty<BaseNode>();
        }
    }

    public async Task<IEnumerable<BaseAlarm>> LoadAlarmNodeConfig()
    {
        var result = new List<BaseAlarm>();
        try
        {
            if (!File.Exists(_config.AnalogAlarmPath))
            {
                Console.WriteLine("Конфігурація вузлів аналогових аварій відсутня");
                return Enumerable.Empty<BaseAlarm>();
            }

            string analogJSON = await File.ReadAllTextAsync(_config.AnalogAlarmPath);
            var analogAlarms = JsonSerializer.Deserialize<List<AnalogAlarm>>(analogJSON);
            if (analogAlarms != null)
                result.AddRange(analogAlarms);

            if (!File.Exists(_config.DiscreteAlarmPath))
            {
                Console.WriteLine("Конфігурація вузлів дискретних аварій відсутня");
                return Enumerable.Empty<BaseAlarm>();
            }

            string discreteJSON = await File.ReadAllTextAsync(_config.DiscreteAlarmPath);
            var discreteAlarms = JsonSerializer.Deserialize<List<DiscreteAlarm>>(discreteJSON);
            if (discreteAlarms != null)
                result.AddRange(discreteAlarms);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка считування конфігу вузлів аварій: {ex.Message}");
            return Enumerable.Empty<BaseAlarm>();
        }
        return result.AsEnumerable();
    }
}