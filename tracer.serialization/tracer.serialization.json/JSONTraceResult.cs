using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tracer.serialization.json
{
    public class JSONTraceResult
    {
        [JsonPropertyName("threads")] public List<JSONTracedThreads> Threads { get; }

        public JSONTraceResult(List<JSONTracedThreads> threads)
        {
            Threads = threads;
        }
    }
}
