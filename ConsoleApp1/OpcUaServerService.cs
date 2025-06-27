using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleReferenceServer
{
    public class OpcUaServerService
    {
        private List<BaseNode> nodes;
        private bool isRunning;

        public OpcUaServerService()
        {
            nodes = new List<BaseNode>();
            isRunning = false;
        }

        public async Task StartAsync()
        {
            Console.WriteLine("Starting OPC UA Server...");
            
            // Створюємо тестові вузли
            CreateTestNodes();
            
            isRunning = true;
            Console.WriteLine("OPC UA Server started on port 4840");
            Console.WriteLine($"Created {nodes.Count} nodes:");
            
            foreach (var node in nodes)
            {
                Console.WriteLine($"- {node.DisplayName.Text} ({node.NodeId.Identifier})");
            }
        }

        public void Stop()
        {
            isRunning = false;
            Console.WriteLine("OPC UA Server stopped");
        }

        private void CreateTestNodes()
        {
            // Температура
            nodes.Add(new BaseNode
            {
                NodeId = new NodeId { NamespaceIndex = 1, IdentifierType = IdType.Numeric, Identifier = 1001 },
                DisplayName = new DisplayName { Locale = "en", Text = "Temperature" },
                FullPath = "Root/Temperature",
                DataType = new NodeId { NamespaceIndex = 0, IdentifierType = IdType.Numeric, Identifier = 11 }, // Double
                ValueRank = -1,
                AccessLevel = 3, // Read/Write
                UserRolePermissions = new List<UserRolePermission>()
            });

            // Тиск
            nodes.Add(new BaseNode
            {
                NodeId = new NodeId { NamespaceIndex = 1, IdentifierType = IdType.Numeric, Identifier = 1002 },
                DisplayName = new DisplayName { Locale = "en", Text = "Pressure" },
                FullPath = "Root/Pressure",
                DataType = new NodeId { NamespaceIndex = 0, IdentifierType = IdType.Numeric, Identifier = 11 }, // Double
                ValueRank = -1,
                AccessLevel = 1, // Read only
                UserRolePermissions = new List<UserRolePermission>()
            });

            // Статус
            nodes.Add(new BaseNode
            {
                NodeId = new NodeId { NamespaceIndex = 1, IdentifierType = IdType.Numeric, Identifier = 1003 },
                DisplayName = new DisplayName { Locale = "en", Text = "Status" },
                FullPath = "Root/Status",
                DataType = new NodeId { NamespaceIndex = 0, IdentifierType = IdType.Numeric, Identifier = 1 }, // Boolean
                ValueRank = -1,
                AccessLevel = 3, // Read/Write
                UserRolePermissions = new List<UserRolePermission>()
            });
        }

        public bool IsRunning => isRunning;
        public IReadOnlyList<BaseNode> GetNodes() => nodes.AsReadOnly();
    }
}
