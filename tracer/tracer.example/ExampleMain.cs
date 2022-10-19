using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracer.core;
using tracer.example;
using tracer.serialization.abstractions;
using tracer.serialization.json;
using tracer.serialization.plugins;
using tracer.serialization.xml;
using tracer.serialization.yaml;

ITracer tracer = new tracer.core.Tracer();
var testClass1 = new TestClass1(tracer);
var testClass2 = new TestClass2(tracer);

var t1 = new Thread(() =>
{
    testClass1.Method1();
    testClass1.Method2();

});
t1.Start();

var t2 = new Thread(() =>
{
    testClass2.Method1();
    testClass2.Method2();
});
t2.Start();

//testClass1.Method1();
t1.Join();
t2.Join();
var traceResult = tracer.GetTraceResult();




//copy "$(OutDir)*.dll" "D:\5 sem\spp\lab1\spp-lab1\tracer\tracer.example\plugins"
/*
JSON json = new JSON();
json.Serialize(traceResult,Console.OpenStandardOutput());

XML xml = new XML();
xml.Serialize(traceResult, Console.OpenStandardOutput());

YAML yaml = new YAML();
yaml.Serialize(traceResult, Console.OpenStandardOutput());
*/
var pluginFile = "D:\\5 sem\\spp\\lab1\\spp-lab1\\tracer\\tracer.example\\plugins"; 
var pluginLoader = new PluginLoader(pluginFile);
var plugins = pluginLoader.GetAllPlugins();
var resultFile = pluginFile + "\\result\\";

foreach (var plugin in plugins)
{
    using var fileStream = new FileStream($"{resultFile}.{plugin.Format}", FileMode.Create);
    plugin.Serialize(traceResult, fileStream);
}
