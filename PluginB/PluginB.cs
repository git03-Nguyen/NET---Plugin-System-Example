using SharedContract;

namespace PluginB
{
    public class PluginB : IPlugin
    {
        public string Name => "PluginB"; 

        public void Run()
        {
            Console.WriteLine("PluginB is running");
        }
    }
}
