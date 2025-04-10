using System.Collections.Generic;

public interface IAddConfig
{
    Task<List<BaseNode>?> LoadBaseNodeConfig();
    Task<List<BaseAlarm>?> LoadAlarmNodeConfig();
}