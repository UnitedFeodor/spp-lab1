using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer.core
{
    public class ThreadInfo
    {
        public ConcurrentStack<MethodInfo> CallStack { get; set; }
        public List<MethodInfo> RootMethods { get; set; }
        public ThreadInfo()
        {
            RootMethods = new List<MethodInfo>();
            CallStack = new ConcurrentStack<MethodInfo>();
            
        }
    }
}
