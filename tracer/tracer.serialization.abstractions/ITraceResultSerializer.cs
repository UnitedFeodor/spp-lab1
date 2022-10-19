using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.serialization.abstractions
{
    public interface ITraceResultSerializer
    {

        string Format { get; }
        void Serialize(TraceResult traceResult, Stream to);
    }
}
