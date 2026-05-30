
namespace PatternsApp
{
    // Factory pattern
    public static class PluginFactory
    {
        public static IPlugin CreatePlugin(string type)
        {
            if (type == "default")
                return new DefaultPlugin();

            return new DefaultPlugin();
        }
    }
}
