
using System;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Plugin System Demo ===");

            IPlugin plugin = PluginFactory.CreatePlugin("default");
            plugin.Execute();

            // Adapter usage
            LegacyPlugin legacy = new LegacyPlugin();
            IPlugin adapted = new PluginAdapter(legacy);
            adapted.Execute();

            Console.WriteLine("Logger instance test:");
            Logger.Instance.Log("Singleton works!");

            Console.ReadLine();
        }
    }
}
