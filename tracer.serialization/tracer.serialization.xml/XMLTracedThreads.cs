using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tracer.serialization.xml
{
    public class XMLTracedThreads
    {
        [XmlAttribute("id")] public string Id;
        [XmlAttribute("time")] public string Time;
        [XmlElement("method")] public List<XMLTracedMethods> Methods;

        public XMLTracedThreads()
        {
            Id = string.Empty;
            Time = string.Empty;
            Methods = new List<XMLTracedMethods>();
        }

        public XMLTracedThreads(int id, long time, List<XMLTracedMethods> methods)
        {
            Id = id.ToString();
            Time = string.Format("{0}ms", time);
            Methods = methods;
        }
    }
}
