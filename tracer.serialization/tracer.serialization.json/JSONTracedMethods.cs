using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tracer.serialization.abstractions;

namespace tracer.serialization.json
{
    public class JSONTracedMethods
    {
        [JsonPropertyName("name")] public string MethodName { get; }
        [JsonPropertyName("class")] public string ClassName { get; }
        [JsonPropertyName("time")] public string Time { get; }
        [JsonPropertyName("methods")] public IEnumerable<JSONTracedMethods> Methods { get; }

        public JSONTracedMethods(string methodName, string className, long time, IEnumerable<JSONTracedMethods> methods)
        {
            MethodName = methodName;
            ClassName = className;
            Time = string.Format("{0}ms", time);
            Methods = methods;
        }

        public static IEnumerable<JSONTracedMethods> ToJsonMethods(IReadOnlyList<TracedMethods> methods)
        {
            if (methods.Count == 0)
            {
                return null;
            }
            return methods.Select(method => 
                new JSONTracedMethods(method.MethodName, method.ClassName, method.Time, ToJsonMethods(method.Methods)));
        }
    }
}
