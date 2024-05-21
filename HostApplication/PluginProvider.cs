using SharedContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication
{
    internal class PluginProvider
    {

        static Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();

        static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

        // Singleton
        private static PluginProvider? instance = null;
        public static PluginProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PluginProvider();
                }
                return instance;
            }
        }

        private PluginProvider() {}

        public void LoadPlugins()
        {
            plugins.Clear();

            var files = Directory.GetFiles(path, "*.dll");
            foreach (var dll in files)
            {
                var assemblyLoadContext = new AssemblyLoadContext(dll, true);
                var assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
                var types = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t));
                foreach (var type in types)
                {
                    var plugin = Activator.CreateInstance(type) as IPlugin;
                    if (plugin != null)
                    {
                        plugins.Add(plugin.Name, plugin);
                    }
                }
            }
        }

        public void RunPlugin(string name)
        {
            if (plugins.ContainsKey(name))
            {
                plugins[name].Run();
            }
            else
            {
                Console.WriteLine("Plugin not found");
            }
        }
    }
}
