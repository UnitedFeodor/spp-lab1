using NUnit.Framework;
using System.Threading;
using tracer.example;
using tracer.serialization.abstractions;

namespace tracer.core.tests
{
    public class Tests
    {
        private ITracer _tracer;
        private TestClass1 _testClass1;
        private TestClass2 _testClass2;

        [SetUp]
        public void Setup()
        {
            _tracer = new Tracer();
            _testClass1 = new TestClass1(_tracer);
            _testClass2 = new TestClass2(_tracer);
        }

        [Test]
        public void OneThread()
        {
            
            _testClass1.Method1();

            var traceResult = _tracer.GetTraceResult();
            
            
            Assert.That(traceResult.Threads.Count, 
                Is.EqualTo(1));
            Assert.That(traceResult.Threads[0].Methods.Count, 
                Is.EqualTo(1));
            Assert.That(traceResult.Threads[0].Methods[0].MethodName, 
                Is.EqualTo("Method1"));
            Assert.That(traceResult.Threads[0].Methods[0].Time, 
                Is.InRange(250, 350));
            Assert.That(traceResult.Threads[0].Methods[0].Methods.Count, 
                Is.EqualTo(0));             
           
          
        }

        [Test]
        public void MultipleThreads()
        {
            var t1 = new Thread(() =>
            {
                _testClass1.Method1();
                _testClass1.Method2();
            });

            var t2 = new Thread(() =>
            {
                _testClass2.Method1();
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            var traceResult = _tracer.GetTraceResult();

            // thread 1
            Assert.That(traceResult.Threads.Count, 
                Is.EqualTo(2));
            Assert.That(traceResult.Threads[0].Methods.Count, 
                Is.EqualTo(2));

            Assert.That(traceResult.Threads[0].Methods[0].MethodName,
                Is.EqualTo("Method1"));
            Assert.That(traceResult.Threads[0].Methods[0].Time,
                Is.InRange(250, 350));
            Assert.That(traceResult.Threads[0].Methods[0].Methods.Count,
                Is.EqualTo(0));


            Assert.That(traceResult.Threads[0].Methods[1].MethodName,
                Is.EqualTo("Method2"));
            Assert.That(traceResult.Threads[0].Methods[1].Time,
                Is.InRange(50, 150));
            Assert.That(traceResult.Threads[0].Methods[1].Methods.Count,
                Is.EqualTo(0));

            Assert.That(traceResult.Threads[0].Time, Is.InRange(350, 450));

            // thread 2
            Assert.That(traceResult.Threads[1].Methods.Count, Is.EqualTo(1));

            Assert.That(traceResult.Threads[1].Methods[0].MethodName, 
                Is.EqualTo("Method1"));
            Assert.That(traceResult.Threads[1].Methods[0].Time, 
                Is.InRange(450, 550));
            Assert.That(traceResult.Threads[1].Methods[0].Methods.Count, 
                Is.EqualTo(1));


            Assert.That(traceResult.Threads[1].Methods[0].Methods[0].MethodName,
                Is.EqualTo("Method2"));
            Assert.That(traceResult.Threads[1].Methods[0].Methods[0].Time,
                Is.InRange(150, 250));
            Assert.That(traceResult.Threads[1].Methods[0].Methods[0].Methods.Count,
                Is.EqualTo(0));

            Assert.That(traceResult.Threads[1].Time, 
                Is.InRange(450, 550));

        }

       

    }
}