using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SearchRemarks.Model
{
    [Serializable]
    public class Reason
    {
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "CreationTime")]
        public string Created { get; set; }
    }
}
