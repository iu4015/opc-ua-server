using System;
using System.Threading.Tasks;

namespace ConsoleReferenceServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== OPC UA Basic Server ===");
            Console.WriteLine();

            var serverService = new OpcUaServerService();

            try
            {
                // Запускаємо сервер
                await serverService.StartAsync();
                
                Console.WriteLine();
                Console.WriteLine("Press ENTER to stop the server...");
                Console.ReadLine();
                
                // Зупиняємо сервер
                serverService.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
