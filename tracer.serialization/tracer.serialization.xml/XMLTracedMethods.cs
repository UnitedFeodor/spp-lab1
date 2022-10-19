using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using tracer.serialization.abstractions;

namespace tracer.serialization.xml
{
    public class XMLTracedMethods
    {
        [XmlAttribute("name")] public string MethodName;
        [XmlAttribute("class")] public string ClassName;
        [XmlAttribute("time")] public string Time;
        [XmlElement("methods")] public List<XMLTracedMethods> Methods;

        public XMLTracedMethods()
        {
            MethodName = string.Empty;
            ClassName = string.Empty;
            Time = string.Empty;
            Methods = new List<XMLTracedMethods>();
        }

        public XMLTracedMethods(string methodName, string className, long time, List<XMLTracedMethods> methods)
        {
            MethodName = methodName;
            ClassName = className;
            Time = string.Format("{0}ms", time);
            Methods = methods;
        }

        public static List<XMLTracedMethods> ToXmlMethods(IReadOnlyList<TracedMethods> methods)
        {
            if (methods.Count == 0)
            {
                return null;
            }

            return methods.Select(method => new XMLTracedMethods(
                method.MethodName, method.ClassName, method.Time, ToXmlMethods(method.Methods))).ToList();
        }
    }
}
