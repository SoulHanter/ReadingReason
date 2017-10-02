using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SearchRemarks.Model
{
    [Serializable]
    public class DocumentXML
    {
        [XmlAttribute(AttributeName = "RootID")]
        public Guid Resource { get; set; }
        [XmlAttribute(AttributeName = "UserName")]
        public string FromUser { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();
    }
}
