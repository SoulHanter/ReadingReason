using Ascon.Pilot.SDK;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchRemarks.Model;
using SearchRemarks.Utils.Extensions;
using SearchRemarks.Utils.Loader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static SearchRemarks.Ninject.NinjectCommon;

namespace SearchRemarks
{
    public class MapToRemark
    {
        private readonly IObjectsRepository _repository;
        private readonly IFileProvider _fileProvider;
        public MapToRemark(IObjectsRepository repository, IFileProvider fileProvider)
        {
            _repository = repository;
            _fileProvider = fileProvider;
            Initialize();
        }

        private void Initialize()
        {
            Kernel.Inject(this);
            Kernel.Rebind<IFileProvider>().ToMethod(c => _fileProvider).InSingletonScope();
            Kernel.Rebind<IObjectsRepository>().ToMethod(c => _repository).InSingletonScope();
        }

        public void WriteRemarkInXLM(Guid id, int personId)
        {
            var loader = new ObjectLoader(_repository);

            loader.Load(objects =>
            {
                CreateXmlFile(objects.ToList().Reasons(personId, id));
                //CreateXmlFile(objects.ToList().Reasons(personId, id), $@"D:\\Import\\persons.xml");
            }, type => true, id);            
        }

        private void CreateXmlFile(DocumentXML document, string path)
        {
            XmlSerializer format = new XmlSerializer(typeof(DocumentXML));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                format.Serialize(fs, document);
            }
        }

        private void CreateXmlFile(DocumentXML document)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "xml file|*.xml";
            dialog.Title = "Сохранить xml файл";
            dialog.DefaultExt = "*.xml";
            dialog.FileName = DateTime.Now.ToString("D");

            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                XmlSerializer format = new XmlSerializer(typeof(DocumentXML));

                using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    format.Serialize(fs, document);
                }
            }
        }
    }
}
