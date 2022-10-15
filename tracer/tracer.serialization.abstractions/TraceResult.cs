using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.serialization.abstractions
{
    public class TraceResult
    {
        public IReadOnlyList<TracedThreads> Threads { get; }

        public TraceResult(IReadOnlyList<TracedThreads> threads)
        {
            Threads = threads;
        }
    }
}
