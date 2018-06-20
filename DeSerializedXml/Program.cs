using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DeSerializedXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(MultiPackDocuments));

            using (FileStream fs = new FileStream("multipack.xml", FileMode.Open))
            {
                MultiPackDocuments multipackdocuments = (MultiPackDocuments)formatter.Deserialize(fs);
                Console.WriteLine("XML десериализован");
            }
            Console.ReadLine();
        }
    }

    [Serializable]
    [XmlRoot("documents")]
    public class MultiPackDocuments
    {
        [XmlElement("multi_pack")]
        public MultiPack MultiPack { get; set; }
    }

    public class MultiPack
    {
        [XmlElement("subject_id")]
        public string SubjectId { get; set; }

        [XmlElement("operation_date")]
        public DateTime OperationDate { get; set; }

        [XmlElement("by_sgtin")]
        public BySgtin BySgtin { get; set; }

        [XmlElement("by_sscc")]
        public BySscc BySscc { get; set; }
    }

    public class BySscc
    {
        [XmlElement("detail")]
        public DetailSscc Detail { get; set; }
        public BySscc() { }

    }

    public class DetailSscc
    {
        [XmlElement("sscc")]
        public string Sscc { get; set; }

        [XmlArray("content")]
        [XmlArrayItem("sscc", typeof(String))]
        public List<String> Content { get; set; }
        public DetailSscc() { }
    }

    public class DetailSgtin
    {
        [XmlElement("sscc")]
        public string Sscc { get; set; }

        [XmlArray("content")]
        [XmlArrayItem("sgtin", typeof(String))]
        public List<String> Content { get; set; }
        public DetailSgtin() { }
    }

    public class BySgtin
    {
        [XmlElement("detail")]
        public DetailSgtin Detail { get; set; }
        public BySgtin() { }
    }
}
