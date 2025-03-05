// See https://aka.ms/new-console-template for more information
using ConsoleReferenceServer;
using System.Text.Json;

List<UserRolePermission> roles = [
    new UserRolePermission() {
RoleId = new NodeId()
{
    NamespaceIndex = 1,
    IdentifierType = IdType.Numeric,
    Identifier = 2
},
Permissions = 10
},
new UserRolePermission() {
RoleId = new NodeId()
{
    NamespaceIndex = 1,
    IdentifierType = IdType.String,
    Identifier = '2'
},
Permissions = 10
},
];

BaseNode nodetest = new()
{
    NodeId = new NodeId()
    {
        NamespaceIndex = 4,
        IdentifierType = IdType.String,
        Identifier = "ssss"
    },
    DisplayName = new DisplayName
    {
        Locale = "UK",
        Text = "TT"
    },
    FullPath = "Base/TT",
    DataType = new NodeId()
    {
        NamespaceIndex = 5,
        IdentifierType = IdType.Numeric,
        Identifier = 222
    },
    ValueRank = 2,
    AccessLevel = 0,
    UserRolePermissions = [.. roles]

};

string jsonString = JsonSerializer.Serialize(nodetest);

//var node = new BaseNode(new NodeId(1), new LocalizedText("UK", "TT"),
//    "Base/TT", new NodeId(2),new Variant(true),2,0,new RolePermissionTypeCollection(2));
Console.WriteLine(jsonString);
