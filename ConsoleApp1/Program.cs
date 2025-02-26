// See https://aka.ms/new-console-template for more information

using ConsoleReferenceServer;

var node = new BaseNode(new NodeId(1, 0, 1), 2, new BrowseName(1, "TemperatureSensor"), 
    new DisplayName("uk-UA", "Датчик температури"));
Console.WriteLine("Hello, World!");
