using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class AddConfig
{
    public List<BaseNode>? LoadBaseNodeConfig()
    {
        try
        {
            if (!File.Exists("Filepath"))
            {
                Console.WriteLine("Конфігурація основних вузлів відсутня");
                return null;
            }

            string json = File.ReadAllText("Filepath");
            return JsonSerializer.Deserialize<List<BaseNode>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка считування конфігу основних вузлів: {ex.Message}");
            return null;
        }
    }

    public List<AnalogAlarm>? LoadAnalogAlarmNodeConfig()
    {
        try
        {
            if (!File.Exists("Filepath"))
            {
                Console.WriteLine("Конфігурація вузлів аналогових аварій відсутня");
                return null;
            }

            string json = File.ReadAllText("Filepath");
            return JsonSerializer.Deserialize<List<AnalogAlarm>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка считування конфігу вузлів аналогових аварій: {ex.Message}");
            return null;
        }
    }

    public List<DiscreteAlarm>? LoadAnalogAlarmNodeConfig()
    {
        try
        {
            if (!File.Exists("Filepath"))
            {
                Console.WriteLine("Конфігурація вузлів дискретних аварій відсутня");
                return null;
            }

            string json = File.ReadAllText("Filepath");
            return JsonSerializer.Deserialize<List<DiscreteAlarm>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка считування конфігу вузлів дискретних аварій: {ex.Message}");
            return null;
        }
    }
}
