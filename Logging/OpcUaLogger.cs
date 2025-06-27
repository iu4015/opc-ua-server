using Opc.Ua;
using Serilog;
using Serilog.Context;
using System;

namespace OpcUaServer.Logging
{
    // Логування OPC UA вузлів
    public class OpcUaLogger
    {
        private readonly ILogger _logger;

        public OpcUaLogger(ILogger logger)
        {
            _logger = logger;
        }

        // Логує поточне значення вузла та його властивості
        public void LogNodeValue(NodeState node)
        {
            using (LogContext.PushProperty("NodeId", node.NodeId.ToString()))
            using (LogContext.PushProperty("BrowseName", node.BrowseName.ToString()))
            using (LogContext.PushProperty("NodeClass", node.NodeClass.ToString()))
            using (LogContext.PushProperty("DisplayName", node.DisplayName?.Text))
            {
                if (node is BaseVariableState variable)
                {
                    _logger.Information(
                        "Variable node value: {Value}, DataType: {DataType}, AccessLevel: {AccessLevel}", 
                        variable.Value,
                        variable.DataType,
                        variable.AccessLevel);
                }
                else if (node is MethodState method)
                {
                    _logger.Information(
                        "Method node accessed, Executable: {Executable}, UserExecutable: {UserExecutable}",
                        method.Executable,
                        method.UserExecutable);
                }
                else
                {
                    _logger.Information("Node of type {NodeType} accessed", node.GetType().Name);
                }
            }
        }

        // Логує зміну значення вузла
        public void LogNodeValueChange(NodeState node, object oldValue, object newValue)
        {
            using (LogContext.PushProperty("NodeId", node.NodeId.ToString()))
            using (LogContext.PushProperty("BrowseName", node.BrowseName.ToString()))
            {
                _logger.Information("Node value changed from {OldValue} to {NewValue}", 
                    oldValue?.ToString() ?? "null", 
                    newValue?.ToString() ?? "null");
            }
        }

        // Логує дії з вузлом (читання, запис, тощо)
        public void LogNodeAccess(NodeState node, string action)
        {
            using (LogContext.PushProperty("NodeId", node.NodeId.ToString()))
            using (LogContext.PushProperty("BrowseName", node.BrowseName.ToString()))
            {
                _logger.Information("Node {Action}", action);
            }
        }

        public void LogError(string message, Exception ex = null)
        {
            if (ex != null)
                _logger.Error(ex, message);
            else
                _logger.Error(message);
        }
    }
}
