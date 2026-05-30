
using System;

namespace PatternsApp
{
    public class DefaultPlugin : IPlugin
    {
        public void Execute()
        {
            Console.WriteLine("Default plugin executed.");
        }
    }
}
