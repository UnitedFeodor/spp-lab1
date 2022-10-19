using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.serialization.yaml
{
    public class YAMLTracedThreads
    {
        public string Id { get; }
        public string Time { get; }
        public List<YAMLTracedMethods> Methods { get; }

        internal YAMLTracedThreads(int id, long time, List<YAMLTracedMethods> methods)
        {
            Id = id.ToString();
            Time = String.Format("{0}ms", time);
            Methods = methods;
        }
    }

}
