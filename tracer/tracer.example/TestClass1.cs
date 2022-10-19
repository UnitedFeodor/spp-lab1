using tracer.core;

namespace tracer.example
{
    public class TestClass1
    {
        private readonly ITracer _tracer;

        public TestClass1(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(300);
            _tracer.StopTrace();
        }

        public void Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }

    }
}