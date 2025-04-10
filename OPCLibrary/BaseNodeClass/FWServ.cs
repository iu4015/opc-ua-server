//using Opc.Ua;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System;
using OPCLibrary.BaseNodeClass;
using OPC_ua_modules;


public interface IConfigurationService
{
    event EventHandler ConfigurationServiceChanged;//���� ���� �������
    List<BaseNode>? LoadBaseNodeConfig();
    List<AnalogAlarm>? LoadAnalogAlarmNodeConfig();
    List<DiscreteAlarm>? LoadDiscreteAlarmNodeConfig();
}

public class ConfigurationService : IDisposable//IConfigurationService, IDisposable
{
    private readonly string _configDirectory;//��������� � �������
    private readonly FileSystemWatcher _watcher;//���������

    public event EventHandler? ConfigurationServiceChanged;

    public ConfigurationService(string configDirectory)
    {
        _configDirectory = configDirectory;
        _watcher = new FileSystemWatcher(_configDirectory)
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
            Filter = "*.json",
            EnableRaisingEvents = true//����� ��������
        };

        _watcher.Changed += OnConfigChanged;
        _watcher.Created += OnConfigChanged;
        _watcher.Deleted += OnConfigChanged;
    }

    private void OnConfigChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType is WatcherChangeTypes.Changed or WatcherChangeTypes.Created or WatcherChangeTypes.Deleted)
        {
            Console.WriteLine($"���� ������������ ������: {e.FullPath}");
            ConfigurationServiceChanged?.Invoke(this, e);//������ ��䳿 ��� ����
        }
    }

    public void Dispose()
    {
        //_watcher.Dispose();
    }

    //public List<BaseNode>? LoadBaseNodeConfig()
    //{
    //    string filePath = Path.Combine(_configDirectory, "baseNodeConfig.json");
    //    try
    //    {
    //        if (!File.Exists(filePath))
    //        {
    //            Console.WriteLine("������������ �������� ����� �������");
    //            return null;
    //        }

    //        string json = File.ReadAllText(filePath);
    //        return JsonSerializer.Deserialize<List<BaseNode>>(json);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"������� ������� ������������ �������� �����: {ex.Message}");
    //        return null;
    //    }
    //}

    //public List<AnalogAlarm>? LoadAnalogAlarmNodeConfig()
    //{
    //    string filePath = Path.Combine(_configDirectory, "analogAlarmConfig.json");
    //    try
    //    {
    //        if (!File.Exists(filePath))
    //        {
    //            Console.WriteLine("������������ ����� ���������� ����� �������");
    //            return null;
    //        }

    //        string json = File.ReadAllText(filePath);
    //        return JsonSerializer.Deserialize<List<AnalogAlarm>>(json);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"������� ������� ������������ ����� ���������� �����: {ex.Message}");
    //        return null;
    //    }
    //}

    //public List<DiscreteAlarm>? LoadDiscreteAlarmNodeConfig()
    //{
    //    string filePath = Path.Combine(_configDirectory, "discreteAlarmConfig.json");
    //    try
    //    {
    //        if (!File.Exists(filePath))
    //        {
    //            Console.WriteLine("������������ ����� ���������� ����� �������");
    //            return null;
    //        }

    //        string json = File.ReadAllText(filePath);
    //        return JsonSerializer.Deserialize<List<DiscreteAlarm>>(json);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"������� ������� ������������ ����� ���������� �����: {ex.Message}");
    //        return null;
    //    }
    //}

}
