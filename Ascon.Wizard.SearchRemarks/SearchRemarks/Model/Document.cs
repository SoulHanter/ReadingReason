using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SearchRemarks.Model
{
    [Serializable]
    public class Document
    {
        [XmlAttribute(AttributeName = "ID")]
        public Guid Id { get; set; }
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "Designation")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "User")]
        public string ToUser { get; set; }
        public List<Reason> Reasons { get; set; } = new List<Reason>();
    }
}
