using System.Xml;
using System.Xml.Serialization;
using tracer.serialization.abstractions;

namespace tracer.serialization.xml
{
    public class XML : ITraceResultSerializer
    {
        private string _format = "xml";
        public string Format => _format;

        public void Serialize(TraceResult traceResult, Stream to)
        {
            List<XMLTracedThreads> threadTraces = traceResult.Threads.Select(thread => new XMLTracedThreads(
                thread.Id, thread.Time, XMLTracedMethods.ToXmlMethods(thread.Methods))).ToList();

            var res = new XMLTraceResult(threadTraces);
            using (var xmlWriter = XmlWriter.Create(to, new XmlWriterSettings { Indent = true }))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLTraceResult));
                xmlSerializer.Serialize(xmlWriter, new XMLTraceResult(threadTraces));
            }
        }
    }










}