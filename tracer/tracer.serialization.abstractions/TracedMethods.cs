using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.serialization.abstractions
{
    public class TracedMethods
    {
        public string MethodName { get; }
        public string ClassName { get; }
        public long Time { get; }
        public IReadOnlyList<TracedMethods> Methods { get; }

        public TracedMethods(string methodName, string className, long time, IReadOnlyList<TracedMethods> methods)
        {
            MethodName = methodName;
            ClassName = className;
            Time = time;
            Methods = methods;
        }
    }
}
