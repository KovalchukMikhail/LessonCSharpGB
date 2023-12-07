using System.Text;
using System.Xml.Linq;
using System;
using System.Xml;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace HomeWork009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlText = """
                           <?xml version="1.0" encoding="utf-8" ?>
                           <people>
                             <person>
                               <name>Tom</name>
                               <company>Microsoft</company>
                               <age>37</age>
                             </person>
                             <person>
                               <name>Bob</name>
                               <company>Google</company>
                               <age>41</age>
                             </person>
                           </people> 
                           """;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlText);
            string jsonTexr = JsonConvert.SerializeXmlNode(doc);
            Console.WriteLine(jsonTexr);
            Console.WriteLine("Сериализуем обратно в XML");
            XmlDocument returnedDoc = JsonConvert.DeserializeXmlNode(jsonTexr);
            Console.WriteLine(returnedDoc.OuterXml);
        }
    }
}
