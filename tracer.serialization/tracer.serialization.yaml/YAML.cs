using tracer.serialization.abstractions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace tracer.serialization.yaml
{
    public class YAML : ITraceResultSerializer
    {
        private string _format = "yaml";
        public string Format => _format;

        public void Serialize(TraceResult traceResult, Stream to)
        {
            List<YAMLTracedThreads> threadTraces = traceResult.Threads.Select(thread => 
                new YAMLTracedThreads(thread.Id, thread.Time, YAMLTracedMethods.ToYamlMethods(thread.Methods))).ToList();

            var serializer = new SerializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();

            var yaml = serializer.Serialize(new YAMLTraceResult(threadTraces));
            var sw = new StreamWriter(to);
            serializer.Serialize(sw, new YAMLTraceResult(threadTraces));
            sw.Flush();
        }
    }

    
}