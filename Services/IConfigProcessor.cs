public interface IConfigProcessor
{
    void ProcessNodes(List<BaseNode> nodes);
    void ProcessAlarms(List<BaseAlarm> alarms);
}