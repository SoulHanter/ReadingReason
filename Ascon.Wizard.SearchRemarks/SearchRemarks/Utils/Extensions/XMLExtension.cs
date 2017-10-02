using SearchRemarks.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SearchRemarks.Utils.Extensions
{
    public static class XMLExtension
    {
        public static Reason GetReason(this Stream source)
        {
            if (source == null)
                return null;

            XDocument doc = XDocument.Load(source);

            XElement reason = doc?.Root.Elements()?.FirstOrDefault(x => x.Name.LocalName.Equals("Cargos"))?
                                       .Elements()?.FirstOrDefault(x => x.Attribute("Name").Value.Equals("Text Data"))?
                                       .Elements()?.FirstOrDefault(x => !x.Attributes().Any());

            var createDate = doc?.Root.Attribute("CreationTime")?.Value ?? DateTime.Now.ToString();
            

            var context = reason?.Value?.Base64ToString()?
                                        .BytesToString()?
                                        .StringToStream();

            var reasonContext = context?.GetReasonText();

            return reasonContext != null ? new Reason { Text = reasonContext, Created = createDate } : null;
        }

        private static string GetReasonText(this Stream source)
        {
            string resource = null;

            if (source == null)
                return resource;

            XElement reasonContext = XElement.Load(source);

            var paragraphs = reasonContext?.Elements()?
                                           .Where(x => x.Name.LocalName.Equals("Paragraph"));

            if (paragraphs.Any())
            {
                foreach (var paragraph in paragraphs)
                {
                    resource += $"{paragraph?.Value}\n";
                }
            }
            
            return resource.TrimEnd('\n');
        }
    }
}
