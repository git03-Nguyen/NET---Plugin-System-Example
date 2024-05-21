using System.Reflection;
using System.Runtime.Loader;
using SharedContract;

namespace HostApplication
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Start Host Application");

            var pluginProvider = PluginProvider.Instance;

            while (true)
            {
                Console.WriteLine("Enter plugin name to run or 'q' to quit");
                var input = Console.ReadLine();
                if (input == null || input == "q")
                {
                    break;
                }
                pluginProvider.LoadPlugins();
                pluginProvider.RunPlugin(input);
            }


            Console.WriteLine("End Host Application");
        }
    }
}
