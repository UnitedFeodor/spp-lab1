using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracer.serialization.abstractions;

namespace tracer.core
{
    public class Tracer : ITracer
    {
        private readonly ConcurrentDictionary<int, ThreadInfo> _threads = new();

        private static List<TracedMethods> GetInnerMethods(MethodInfo rootMethod)
        {
            var tracedMethods = new List<TracedMethods>();
            foreach (var method in rootMethod.InnerMethods)
            {
                tracedMethods.Add(new TracedMethods(method.MethodName, method.ClassName,
                    method.Stopwatch.ElapsedMilliseconds, GetInnerMethods(method)));
            }
            return tracedMethods;
        }
        public TraceResult GetTraceResult()
        {
            var threads = new List<TracedThreads>();
            foreach (var thread in _threads)
            {
                var methods = new List<TracedMethods>();
                
                foreach (MethodInfo method in thread.Value.RootMethods)
                {
                    methods.Add(new TracedMethods(method.MethodName, method.ClassName,
                        method.Stopwatch.ElapsedMilliseconds, GetInnerMethods(method)));
                }
                threads.Add(new TracedThreads(thread.Key, methods));
            }

            return new TraceResult(threads);
        }

        public void StartTrace()
        {
            var method = new System.Diagnostics.StackTrace().GetFrame(1)?.GetMethod();
            var className = method.DeclaringType != null ? method.DeclaringType.Name : string.Empty;
            var methodInfo = new MethodInfo(method.Name, className, new Stopwatch());

            var threadId = Environment.CurrentManagedThreadId;
            var threadInfo = _threads.GetOrAdd(threadId, new ThreadInfo());

            if (threadInfo.CallStack.IsEmpty)
            {
                threadInfo.RootMethods.Add(methodInfo);
            }
            else
            {
                var parentMethod = threadInfo.CallStack.First();
                parentMethod.InnerMethods.Add(methodInfo);
            }

            threadInfo.CallStack.Push(methodInfo);
            methodInfo.Stopwatch.Start();


        }

        public void StopTrace()
        {
            MethodInfo methodInfo;
            if (!_threads[Environment.CurrentManagedThreadId].CallStack.TryPop(out methodInfo))
                return;
            methodInfo.Stopwatch.Stop();
        }

    }
}
