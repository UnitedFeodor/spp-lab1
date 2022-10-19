using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracer.serialization.abstractions;

namespace tracer.serialization.yaml
{
    public class YAMLTracedMethods
    {
        public string MethodName { get; }
        public string ClassName { get; }
        public string Time { get; }
        public List<YAMLTracedMethods> Methods { get; }

        public YAMLTracedMethods(string methodName, string className, long time, List<YAMLTracedMethods> methods)
        {
            MethodName = methodName;
            ClassName = className;
            Time = String.Format("{0}ms", time);
            Methods = methods;
        }

        public static List<YAMLTracedMethods> ToYamlMethods(IReadOnlyList<TracedMethods> methods)
        {
            if (methods.Count == 0)
            {
                return null;
            }
            return methods.Select(method => new YAMLTracedMethods(
                method.MethodName, method.ClassName, method.Time, ToYamlMethods(method.Methods))).ToList();
        }
    }
}
