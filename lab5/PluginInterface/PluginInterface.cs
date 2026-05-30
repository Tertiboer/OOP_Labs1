using System;
using System.Collections.Generic;

namespace PluginInterface
{
    /// <summary>
    /// Interface for data processing plugins (Lab 5).
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Unique name of the plugin displayed in the UI.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of what the plugin does.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Dictionary representing plugin settings (For the 10-point task).
        /// </summary>
        Dictionary<string, string> Settings { get; set; }

        /// <summary>
        /// Processes data before it is saved to a file.
        /// </summary>
        byte[] ProcessBeforeSave(byte[] inputData);

        /// <summary>
        /// Reverses processing after data is loaded from a file.
        /// </summary>
        byte[] ProcessAfterLoad(byte[] inputData);

        /// <summary>
        /// Displays or updates settings via console prompt or custom configuration logic.
        /// </summary>
        void Configure();
    }
}