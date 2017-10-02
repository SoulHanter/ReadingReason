using Ascon.Pilot.SDK;
using Ninject;
using SearchRemarks.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using static SearchRemarks.Ninject.NinjectCommon;

namespace SearchRemarks.Utils.Extensions
{
    public static class ReasonExtension
    {
        private static IObjectsRepository _repository => Kernel.Get<IObjectsRepository>();

        public static DocumentXML Reasons(this List<IDataObject> source, int personId, Guid id)
        {
            var documentXML = new DocumentXML() { Resource = id, FromUser = _repository.GetCurrentPerson().ActualName };            

            var items = source.Where(x => x.ObjectStateInfo.State == ObjectState.Alive &&
                                          x.Files.Any());
            if (items.Any())
            {
                foreach (var item in items)
                {
                    documentXML.Documents.Add(item.GetDocument(personId));
                }
            }              

            return documentXML;
        }

        private static Document GetDocument(this IDataObject source, int personId)
        {           
            var doc = new Document()
            {
                Id = source.Id,
                Title = source.DisplayName,
                Name = source.Attributes.ContainsKey("Document_code") ? source.Attributes["Document_code"].ToString() : null,
                ToUser = source.Creator.ActualName
            };

            //получаем аннотацию
            var files = source.ActualFileSnapshot.Files.Where(x => x.Name.Contains("Annotation"));
            
            //загружаем аннотацию
            var streams = files.MapToStream();

            if (!streams.Any())
                return doc;

            foreach (var stream in streams)
            {
                var reason = stream?.GetReason();

                if (reason != null)
                {
                    doc.Reasons.Add(reason);
                }
            }

            return doc;
        }
       
    }
}
