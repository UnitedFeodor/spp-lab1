using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.core
{
    public class MethodInfo
    {
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public Stopwatch Stopwatch { get; } = new Stopwatch();
        public List<MethodInfo> InnerMethods { get; } = new List<MethodInfo>();

        public MethodInfo(string methodName, string className, Stopwatch stopwatch)
        {
            MethodName = methodName;
            ClassName = className;
            Stopwatch = stopwatch;
        }
    }
}
