using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReferenceServer
{
    public enum IdType
    {
        Numeric = 0,
        String = 1,
        Guid = 2,
        Opaque = 3
    };

    public enum NodeClass
    {
        Unspecified = 0,
        Object = 1,
        Variable = 2,
        Method = 4,
        ObjectType = 8,
        VariableType = 16,
        ReferenceType = 32,
        DataType = 64,
        View = 128
    }
    public struct NodeId
    {
        public ushort NamespaceIndex;
        public IdType IdentifierType;
        public object Identifier;
        public NodeId(ushort namespaceIndex, int identifierType, object identifier)
        {
            NamespaceIndex = namespaceIndex;
            IdentifierType = (IdType)identifierType;
            SetIdentifier(identifier);
        }

        private void SetIdentifier(object identifier)
        {
            switch (IdentifierType)
            {
                case IdType.Numeric when identifier is int:
                case IdType.String when identifier is string:
                case IdType.Guid when identifier is Guid:
                case IdType.Opaque: // Будь-який формат, визначений сервером
                    Identifier = identifier;
                    break;
                default:
                    throw new ArgumentException("Невірний тип ідентифікатора для обраного IdType.");
            }
        }

    }

    public class BrowseName
    {
        public ushort NamespaceIndex { get; set; }
        public string Name { get; set; }

        public BrowseName(ushort namespaceIndex, string name)
        {
            NamespaceIndex = namespaceIndex;
            Name = name;
        }
    }

    public class DisplayName
    {
        public string Locale { get; set; }
        public string Text { get; set; }

        public DisplayName(string locale, string text)
        {
            Locale = locale;
            Text = text;
        }
    }
    public class BaseNode
    {
        public NodeId nodeId;
        public NodeClass nodeClass;
        public BrowseName browseName;
        public DisplayName displayName;

        public BaseNode(NodeId nodeid, int nodeclass, BrowseName browsename, DisplayName displayname)
        {
            nodeId = nodeid;
            nodeClass = (NodeClass)nodeclass;
            browseName = browsename;
            displayName = displayname;
        }
    }
}
