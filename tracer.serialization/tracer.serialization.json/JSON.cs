using System.Text.Json;
using System.Text.Json.Serialization;
using tracer.serialization.abstractions;

namespace tracer.serialization.json
{   
   public class JSON : ITraceResultSerializer
    {
        private string _format = "json";
        public string Format => _format;

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };


            JsonSerializer.Serialize(to, 
                new JSONTraceResult(traceResult.Threads.Select(
                    thread => 
                    new JSONTracedThreads(thread.Id, thread.Time, JSONTracedMethods.ToJsonMethods(thread.Methods)))
                .ToList()), options);
        }
    }
}