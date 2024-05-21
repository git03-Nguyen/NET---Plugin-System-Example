using SharedContract;

namespace PluginA
{
    public class PluginA : IPlugin
    {
        public string Name => "PluginA";

        public void Run()
        {
            Console.WriteLine("PluginA is running");
        }
    }
}
