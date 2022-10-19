using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.serialization.yaml
{
    public class YAMLTraceResult
    {
        public List<YAMLTracedThreads> Threads { get; }

        public YAMLTraceResult(List<YAMLTracedThreads> threads)
        {
            Threads = threads;
        }
    }
}
