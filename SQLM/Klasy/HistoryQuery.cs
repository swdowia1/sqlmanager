using System.Xml.Serialization;

namespace SQLM.Klasy
{
    [XmlRoot(ElementName = "Query2")]
    public class Query2
    {
        [XmlElement(ElementName = "Title")] public string Title { get; set; }

        [XmlElement(ElementName = "Text")] public string Text { get; set; }
    }

    [XmlRoot(ElementName = "HistoryQuery2")]
    public class HistoryQuery2
    {
        [XmlElement(ElementName = "Question")] public string Question { get; set; }

        [XmlElement(ElementName = "Title")] public string Title { get; set; }

        [XmlElement(ElementName = "Query2")] public List<Query2> Query { get; set; }
    }
}