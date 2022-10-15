using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.serialization.abstractions
{
    public class TracedThreads
    {
        public int Id { get; }
        public long Time { get; }
        public IReadOnlyList<TracedMethods> Methods { get; }

        public TracedThreads(int id, IReadOnlyList<TracedMethods> methods)
        {
            Id = id;
            Methods = methods;
            Time = methods.Sum(m => m.Time);
        }
    }
}
