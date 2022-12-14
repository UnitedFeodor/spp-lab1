using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracer.serialization.abstractions;

namespace tracer.core
{
    public interface ITracer
    {
        void StartTrace();

        // вызывается в конце замеряемого метода
        void StopTrace();

        // получить результаты измерений
        TraceResult GetTraceResult();
    }
}
