using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using PluginInterface;

namespace CoreApp
{
    class Program
    {
        // Lists to store loaded and actively running plugins
        private static List<IPlugin> _loadedPlugins = new List<IPlugin>();
        private static List<IPlugin> _activePipeline = new List<IPlugin>();

        // Path configuration
        private static string _pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
        private static string _targetFilePath = "data_output.dat";

        static void Main(string[] args)
        {
            // Ensure the automated plugin directory exists on startup
            if (!Directory.Exists(_pluginsDirectory))
            {
                Directory.CreateDirectory(_pluginsDirectory);
            }

            // Task Requirement: Automatically scan and load plugins from the folder
            AutoLoadPlugins();

            // Launch the user interface loop
            RunMainMenu();
        }

        /// <summary>
        /// Scans the /plugins directory and automatically attempts to load all DLL files.
        /// </summary>
        static void AutoLoadPlugins()
        {
            if (!Directory.Exists(_pluginsDirectory)) return;

            string[] dllFiles = Directory.GetFiles(_pluginsDirectory, "*.dll");
            foreach (string file in dllFiles)
            {
                LoadPluginFromFile(file);
            }
        }

        /// <summary>
        /// Dynamically loads a .dll assembly using Reflection and looks for implementations of IPlugin.
        /// </summary>
        static void LoadPluginFromFile(string filePath)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(filePath);
                foreach (Type type in assembly.GetTypes())
                {
                    // Check if the type implements IPlugin, and is a valid concrete class
                    if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);

                        // Avoid duplicates in the UI listing
                        if (!_loadedPlugins.Exists(p => p.Name == plugin.Name))
                        {
                            _loadedPlugins.Add(plugin);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error evaluating file {Path.GetFileName(filePath)}: {ex.Message}");
            }
        }

        /// <summary>
        /// Standard user console menu loop interface.
        /// </summary>
        static void RunMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MAIN APPLICATION SYSTEM ===");
                Console.WriteLine($"Active Plugins in Pipeline: {_activePipeline.Count}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Save Data Structure to File (Applies Active Plugins)");
                Console.WriteLine("2. Load Data Structure from File (Reverses Active Plugins)");
                Console.WriteLine("3. Open Plugin Settings & Management Menu");
                Console.WriteLine("4. Manually Choose and Load a Plugin File (.dll)");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an action (1-5): ");

                switch (Console.ReadLine())
                {
                    case "1": SaveDataWorkflow(); break;
                    case "2": LoadDataWorkflow(); break;
                    case "3": PluginSettingsMenu(); break;
                    case "4": ManualPluginLoadUI(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to retry...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Collects data from the user, passes it through the plugin pipeline, and saves it.
        /// </summary>
        static void SaveDataWorkflow()
        {
            Console.WriteLine("\n--- Processing and Saving Data Structure ---");
            Console.Write("Enter text data to mock a structure (e.g. XML/Objects): ");
            string dataInput = Console.ReadLine();

            // Convert string structure to base byte array representation
            byte[] dataBytes = Encoding.UTF8.GetBytes(dataInput);

            // Sequentially run data transformations using loaded plugins before saving
            foreach (var plugin in _activePipeline)
            {
                Console.WriteLine($"-> Executing transformation: {plugin.Name}");
                dataBytes = plugin.ProcessBeforeSave(dataBytes);
            }

            // Commit final bytes to disk
            File.WriteAllBytes(_targetFilePath, dataBytes);
            Console.WriteLine($"\nSuccess! File written to '{_targetFilePath}' ({dataBytes.Length} bytes).");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        /// <summary>
        /// Reads encrypted/archived bytes from disk and completely reverses the pipeline sequence.
        /// </summary>
        static void LoadDataWorkflow()
        {
            Console.WriteLine("\n--- Loading and Reversing Transformations ---");
            if (!File.Exists(_targetFilePath))
            {
                Console.WriteLine($"Error: Target file '{_targetFilePath}' does not exist yet. Please save data first.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }

            byte[] dataBytes = File.ReadAllBytes(_targetFilePath);
            Console.WriteLine($"Read raw file: {dataBytes.Length} bytes.");

            // Loop in reverse order to undo transformations correctly (e.g., Decrypt, then Decompress)
            for (int i = _activePipeline.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"<- Reversing transformation: {_activePipeline[i].Name}");
                dataBytes = _activePipeline[i].ProcessAfterLoad(dataBytes);
            }

            // Restore human-readable text from final byte chain
            string resultText = Encoding.UTF8.GetString(dataBytes);
            Console.WriteLine("\n=================================");
            Console.WriteLine("RECONSTRUCTED DATA STRUCTURE:");
            Console.WriteLine(resultText);
            Console.WriteLine("=================================");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        /// <summary>
        /// Submenu designed to satisfy Variant settings and the 10-point configuration requirements.
        /// </summary>
        static void PluginSettingsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PLUGIN SETTINGS & MANAGEMENT ===");

                if (_loadedPlugins.Count == 0)
                {
                    Console.WriteLine("\n[No plugins loaded. Please drop compiled DLLs into the /plugins directory]");
                }
                else
                {
                    for (int i = 0; i < _loadedPlugins.Count; i++)
                    {
                        bool isActive = _activePipeline.Contains(_loadedPlugins[i]);
                        Console.WriteLine($"{i + 1}. [{(isActive ? "ACTIVE" : "DISABLED")}] {_loadedPlugins[i].Name}");
                        Console.WriteLine($"   Description: {_loadedPlugins[i].Description}");
                        foreach (var setting in _loadedPlugins[i].Settings)
                        {
                            Console.WriteLine($"   Config Parameter -> {setting.Key}: {setting.Value}");
                        }
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("A. Toggle Plugin Execution Status (On/Off)");
                Console.WriteLine("B. Configure Plugin Parameter Attributes (10-Point Task)");
                Console.WriteLine("C. Back to Main System Menu");
                Console.Write("\nSelect an option: ");

                string selection = Console.ReadLine().ToUpper();
                if (selection == "C") break;

                if (selection == "A")
                {
                    Console.Write("Enter the number of the plugin to toggle: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _loadedPlugins.Count)
                    {
                        IPlugin chosenPlugin = _loadedPlugins[index - 1];
                        if (_activePipeline.Contains(chosenPlugin))
                        {
                            _activePipeline.Remove(chosenPlugin);
                        }
                        else
                        {
                            _activePipeline.Add(chosenPlugin);
                        }
                    }
                }
                else if (selection == "B")
                {
                    Console.Write("Enter the number of the plugin to configure: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _loadedPlugins.Count)
                    {
                        // Delegate configuration workflow UI responsibilities directly to the targeted module instance
                        _loadedPlugins[index - 1].Configure();
                    }
                }
            }
        }

        /// <summary>
        /// Allows a user to open a custom filepath dialogue path to load a plugin manually.
        /// </summary>
        static void ManualPluginLoadUI()
        {
            Console.Write("\nEnter the exact absolute path to a plugin assembly (.dll): ");
            string targetPath = Console.ReadLine();

            if (File.Exists(targetPath))
            {
                LoadPluginFromFile(targetPath);
                Console.WriteLine("File scan complete. Check Settings menu to verify if verified objects loaded.");
            }
            else
            {
                Console.WriteLine("Error: Specified file path could not be located.");
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}