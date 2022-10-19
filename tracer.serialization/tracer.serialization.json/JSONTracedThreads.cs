using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tracer.serialization.json
{
    public class JSONTracedThreads
    {
        [JsonPropertyName("id")] public string Id { get; }
        [JsonPropertyName("time")] public string Time { get; }
        [JsonPropertyName("methods")] public IEnumerable<JSONTracedMethods> Methods { get; }

        public JSONTracedThreads(int id, long time, IEnumerable<JSONTracedMethods> methods)
        {
            Id = id.ToString();
            Time = string.Format("{0}ms", time);
            Methods = methods;
        }
    }
}
