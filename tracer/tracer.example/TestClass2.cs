using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracer.core;

namespace tracer.example
{
    public class TestClass2
    {
        private ITracer _tracer;

        public TestClass2(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(300);
            Method2();
            _tracer.StopTrace();
        }

        public void Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}
