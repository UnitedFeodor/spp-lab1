using System.Reflection;
using tracer.serialization.abstractions;

namespace tracer.serialization.plugins
{
    public class PluginLoader
    {
        private string _filePath { get; }

        public PluginLoader(string path)
        {
            _filePath = path;
        }

        public IEnumerable<ITraceResultSerializer> GetAllPlugins()
        {
            var plugins = new List<ITraceResultSerializer>();
            var directoryInfo = new DirectoryInfo(_filePath);
            var files = directoryInfo.Exists ? directoryInfo.GetFiles("*.dll") : Array.Empty<FileInfo>();
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file.FullName);
                var types = assembly.GetTypes().Where(type => type.IsAssignableTo(typeof(ITraceResultSerializer)));

                plugins.AddRange(types.Select(Activator.CreateInstance)
                    .Where(plugin => plugin != null)
                    .Cast<ITraceResultSerializer>()
                    .ToList());
            }
            
            return plugins;
        }

    }
}