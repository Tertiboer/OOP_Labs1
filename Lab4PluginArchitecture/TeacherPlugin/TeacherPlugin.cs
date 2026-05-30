using System;
using System.Collections.Generic;
using CoreApp.Models;
using CoreApp.Plugins;

namespace TeacherPlugin
{
    /// <summary>
    /// Plugin implementation.
    /// </summary>
    public class TeacherPlugin : IPlugin
    {
        public string PluginName => "Teacher Plugin";

        public Dictionary<string, Func<Person>> RegisterTypes()
        {
            return new Dictionary<string, Func<Person>>
            {
                {
                    "Teacher",
                    () => new Teacher()
                }
            };
        }
    }
}
